using ECommerce.Application.Persistence;
using MediatR;
    
namespace ECommerce.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            GetAllProductsResponse response = new();
            var productsResult  = await productRepository.GetAllAsync();
            var categoriesResult = await categoryRepository.GetAllAsync();
            if (productsResult.IsSuccess && categoriesResult.IsSuccess)
            {
                response.Products = productsResult.Value.Select(p =>
                {
                    var category = categoriesResult.Value.First(category =>
                        category.CategoryId.ToString() == p.CategoryId.ToString());
                    return new ProductDto
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        // Description = c.Description,
                        Price = p.Price,
                        // StockQuantity = c.StockQuantity,
                        CategoryName = category.CategoryName,
                        CategoryId = category.CategoryId,
                        ImageURL = p.ImageURL,
                        // ManufacturerId = c.ManufacturerId,
                    };
                }).ToList();
            }
            return response;
        }
    }
}

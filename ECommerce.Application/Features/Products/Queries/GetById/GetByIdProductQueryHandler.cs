using ECommerce.Application.Persistence;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public GetByIdProductQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.FindByIdAsync(request.Id);
            if (product.IsSuccess)
            {
                var category = (await categoryRepository.FindByIdAsync(product.Value.CategoryId)).Value;
                return new ProductDto
                {
                    ProductId = product.Value.ProductId,
                    ProductName = product.Value.ProductName,
                    // Description = product.Value.Description,
                    Price = product.Value.Price,
                    // StockQuantity = product.Value.StockQuantity,
                    CategoryName =  category.CategoryName,
                    CategoryId = category.CategoryId,
                    ImageURL = product.Value.ImageURL
                    // ManufacturerId = product.Value.ManufacturerId,
                    

                };
            }
            return new ProductDto();
        }
    }
}

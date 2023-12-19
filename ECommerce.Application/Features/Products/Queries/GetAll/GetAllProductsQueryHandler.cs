using ECommerce.Application.Persistence;
using MediatR;
    
namespace ECommerce.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        private readonly IProductRepository repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            GetAllProductsResponse response = new();
            var result = await repository.GetAllAsync();
            if (result.IsSuccess)
            {
                response.Products = result.Value.Select(c => new ProductDto
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Description = c.Description,
                    Price = c.Price,
                    StockQuantity = c.StockQuantity,
                    CategoryId = c.CategoryId,
                    ManufacturerId = c.ManufacturerId,
                }).ToList();
            }
            return response;
        }
    }
}

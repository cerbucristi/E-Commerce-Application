using ECommerce.Application.Persistence;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
    {
        private readonly IProductRepository repository;

        public GetByIdProductQueryHandler(IProductRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.FindByIdAsync(request.Id);
            if (product.IsSuccess)
            {
                return new ProductDto
                {
                    ProductId = product.Value.ProductId,
                    ProductName = product.Value.ProductName,
                    Description = product.Value.Description,
                    Price = product.Value.Price,
                    StockQuantity = product.Value.StockQuantity,
                    CategoryId = product.Value.CategoryId,  
                    ManufacturerId = product.Value.ManufacturerId,
                    

                };
            }
            return new ProductDto();
        }
    }
}

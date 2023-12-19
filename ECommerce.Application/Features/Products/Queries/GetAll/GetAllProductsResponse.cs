namespace ECommerce.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsResponse
    {
        public List<ProductDto> Products { get; set; } = default!;
    }
}
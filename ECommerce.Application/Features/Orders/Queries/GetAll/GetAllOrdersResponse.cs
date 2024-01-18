namespace ECommerce.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrdersResponse
    {
        public List<OrderDto> Orders { get; set; } = default!;
    }
}

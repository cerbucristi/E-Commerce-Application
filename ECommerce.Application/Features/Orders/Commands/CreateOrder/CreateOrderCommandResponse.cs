using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using ECommerce.Application.Responses;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandResponse : BaseResponse
    {
        public CreateOrderCommandResponse() : base()
        {
        }

        public CreateOrderDto Order { get; set; } = default!;
    }
}

using ECommerce.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderViewModel : BaseResponse
    {
        public Guid OrderId { get; set; }
        public string ?OrderStatus { get; set; }
    }
}

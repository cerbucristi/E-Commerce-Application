using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Queries.GetById
{
    public record GetByIdOrderQuery(Guid orderId) : IRequest<OrderDto>;
    
}

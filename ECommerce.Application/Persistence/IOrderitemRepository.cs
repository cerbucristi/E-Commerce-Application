using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Persistence
{
    public interface IOrderItemRepository: IAsyncRepository<OrderItem>
    {
    }
}

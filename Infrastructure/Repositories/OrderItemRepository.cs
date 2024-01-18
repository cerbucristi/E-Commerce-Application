using ECommerce.Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure;
using ECommerce.Application.Persistence;

namespace ECommerce.Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ECommerceContext context) : base(context)
        {

        }
    }
}

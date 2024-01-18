using ECommerce.Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure;
using ECommerce.Application.Persistence;

namespace ECommerce.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceContext context) : base(context)
        {

        }
    }
}

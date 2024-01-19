using ECommerce.Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure;
using ECommerce.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceContext context) : base(context)
        {            
        }
        public async Task<Order> FindByUserId(Guid userId)
        {
            return await context.Orders
                .FirstOrDefaultAsync(w => w.CustomerId == userId);
        }
    }
}

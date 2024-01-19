using ECommerce.Domain.Entities;

namespace ECommerce.Application.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> FindByUserId(Guid userId);
    }
}

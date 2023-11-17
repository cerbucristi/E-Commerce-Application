using ECommerce.Domain.Entities;

namespace ECommerce.Application.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}

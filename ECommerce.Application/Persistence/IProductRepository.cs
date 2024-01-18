using ECommerce.Domain.Entities;

namespace ECommerce.Application.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}

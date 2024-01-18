using ECommerce.Application.Persistence;
using Infrastructure.Repositories;
using Infrastructure;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceContext context) : base(context)
        {

        }
    }
}

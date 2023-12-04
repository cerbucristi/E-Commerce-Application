using ECommerce.Application.Persistence;
using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceContext globaleCommerceContext) : base(globaleCommerceContext)
        {
            
        }
    }
}

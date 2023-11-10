using ECommerce.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(ECommerceContext globaleCommerceContext) : base(globaleCommerceContext)
        {
            
        }
    }
}

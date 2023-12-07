using ECommerce.Application.Persistence;
using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceContext context) : base(context)
        {
            
        }
    }
}

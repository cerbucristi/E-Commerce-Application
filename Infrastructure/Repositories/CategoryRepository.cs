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
   //     public override async Task<Result<Category>> FindByIdAsync(Guid id)
     //   {
      //      var result = await context.Categories.FirstOrDefaultAsync(c => c.CategoryId.Equals(id));   
//if (result == null)
         //   {
         //       return Result<Category>.Failure($"Entity with id {id} not found");
           // }
            //return Result<Category>.Success(result);
       // }
    }
}

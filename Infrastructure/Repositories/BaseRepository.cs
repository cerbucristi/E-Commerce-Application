using ECommerce.Application.Contracts;
using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ECommerceContext context;

        public BaseRepository(ECommerceContext context)
        {
            this.context = context;
            if (!this.context.Database.EnsureCreated()) {
                this.context.Database.Migrate();
            }
        }
        public async Task<Result<T>> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return Result<T>.Success(entity);
        }

        public async Task<Result<T>> DeleteAsync(Guid id)
        {
            var result = await FindByIdAsync(id);
            if (!result.IsSuccess)
            {
                return Result<T>.Failure($"Entity with id {id} not found");
            }
            context.Set<T>().Remove(result.Value);
            await context.SaveChangesAsync();
            return Result<T>.Success(result.Value);
        }

        public async Task<Result<T>> FindByIdAsync(Guid id)
        {
            var result = await context.Set<T>().FindAsync(id);

            if (result == null)
            {
                return Result<T>.Failure($"Entity with {id} not found");
            }
            return Result<T>.Success(result);
        }

        public async Task<Result<IReadOnlyList<T>>> GetPagedReponseAsync(int page, int size)
        {
            var result = await context.Set<T>().Skip(page).Take(size).AsNoTracking().ToListAsync();

            return Result<IReadOnlyList<T>>.Success(result);
        }

        public async Task<Result<T>> UpdateAsync(T entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Result<T>.Success(entity);
        }
    }

}

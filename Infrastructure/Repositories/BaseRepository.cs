﻿using ECommerce.Application.Persistence;
using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ECommerceContext context;

        public BaseRepository(ECommerceContext context)
        {
            this.context = context;
            
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

        public virtual async Task<Result<T>> FindByIdAsync(Guid id)
        {
            var result = await context.Set<T>().FindAsync(id);

            if (result == null)
            {
                return Result<T>.Failure($"Entity with {id} not found");
            }
            return Result<T>.Success(result);
        }
        public async Task<Result<IReadOnlyList<T>>> GetByUserIdAsync(Guid userId)
        {
            var result = await context.Set<T>()
                .Where(entry => EF.Property<Guid>(entry, "UserId") == userId)
                .AsNoTracking()
                .ToListAsync();

            return Result<IReadOnlyList<T>>.Success(result);
        }


        public virtual async Task<Result<IReadOnlyList<T>>> GetAllAsync()
        {
            var result = await context.Set<T>().AsNoTracking().ToListAsync();
            return Result<IReadOnlyList<T>>.Success(result);
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

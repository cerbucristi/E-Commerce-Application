using ECommerce.Application.Persistence;
using Infrastructure.Repositories;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Infrastructure.Repositories
{
    public class WishlistRepository : BaseRepository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(ECommerceContext context) : base(context)
        {
        }
        public async Task<Wishlist> FindByUserIdAndProductIdAsync(Guid userId, Guid productId)
        {
            return await context.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);
        }
    }
}

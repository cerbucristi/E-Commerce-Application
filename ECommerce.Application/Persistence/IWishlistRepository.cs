using ECommerce.Application.Features.Products;
using ECommerce.Application.Features.Wishlists;
using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Persistence
{
    public interface IWishlistRepository : IAsyncRepository<Wishlist>
    {
        Task<Wishlist> FindByUserIdAndProductIdAsync(Guid userId, Guid productId);
    }
}
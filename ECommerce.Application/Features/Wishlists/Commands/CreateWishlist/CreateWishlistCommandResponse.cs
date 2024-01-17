using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Wishlists.Commands.CreateWishlist
{
    public class CreateWishlistCommandResponse : BaseResponse
    {
        public CreateWishlistCommandResponse() : base()
        {
        }

        public CreateWishlistDto Wishlist { get; set; } = default!;
    }
}
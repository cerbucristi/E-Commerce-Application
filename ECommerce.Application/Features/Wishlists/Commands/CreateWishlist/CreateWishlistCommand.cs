using MediatR;

namespace ECommerce.Application.Features.Wishlists.Commands.CreateWishlist
{
    public class CreateWishlistCommand : IRequest<CreateWishlistCommandResponse>
    {
        public Guid ProductId { get; set; } = default!;

    }
}

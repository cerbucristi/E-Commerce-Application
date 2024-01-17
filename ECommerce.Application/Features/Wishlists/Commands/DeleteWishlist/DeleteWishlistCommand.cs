using MediatR;

namespace ECommerce.Application.Features.Events.Commands.DeleteWishlist
{
    public class DeleteWishlistCommand : IRequest<DeleteWishlistCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}

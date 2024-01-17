using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Persistence;
using MediatR;

namespace ECommerce.Application.Features.Events.Commands.DeleteWishlist
{
    public class DeleteWishlistCommandHandler : IRequestHandler<DeleteWishlistCommand, DeleteWishlistCommandResponse>
    {
        private readonly IWishlistRepository wishlistRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteWishlistCommandHandler(IWishlistRepository wishlistRepository, ICurrentUserService _currentUserService)
        {
            this.wishlistRepository = wishlistRepository;
            this._currentUserService = _currentUserService;
        }

        public async Task<DeleteWishlistCommandResponse> Handle(DeleteWishlistCommand request, CancellationToken cancellationToken)
        {
            var userIdString = _currentUserService.GetCurrentUserId();
            Guid userId = Guid.Parse(userIdString);

            var wishlistItem = await wishlistRepository.FindByUserIdAndProductIdAsync(userId, request.ProductId);

            if (wishlistItem == null)
            {
                return new DeleteWishlistCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { "Wishlist item not found." }
                };
            }

            var deleteResult = await wishlistRepository.DeleteAsync(wishlistItem.WishlistId);

            if (!deleteResult.IsSuccess)
            {
                return new DeleteWishlistCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { deleteResult.Error }
                };
            }

            return new DeleteWishlistCommandResponse
            {
                Success = true
            };
        }
    }
}

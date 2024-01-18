using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Persistence;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Wishlists.Commands.CreateWishlist
{
    public class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommand, CreateWishlistCommandResponse>
    {
        private readonly IWishlistRepository wishlistRespository;
        private readonly IProductRepository productRepository;
        private readonly ICurrentUserService _currentUserService;


        public CreateWishlistCommandHandler(IWishlistRepository wishlistRepository, IProductRepository productRepository, ICurrentUserService currentUserService)
        {
            this.wishlistRespository = wishlistRepository;
            this.productRepository = productRepository;
            _currentUserService = currentUserService;

        }

        public async Task<CreateWishlistCommandResponse> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWishlistCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateWishlistCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var product = await productRepository.FindByIdAsync(request.ProductId);
       
            if (!product.IsSuccess)
            {
                return new CreateWishlistCommandResponse
                {
                    Success = false
                };
            }


            var userIdAsString = _currentUserService.GetCurrentUserId();
            Guid userId = Guid.Parse(userIdAsString);

            var existingWishlistItem = await wishlistRespository.FindByUserIdAndProductIdAsync(userId, request.ProductId);
            if (existingWishlistItem != null)
            {
                return new CreateWishlistCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { "Product already exists in the user's wishlist." }
                };
            }

            var wishlist = Wishlist.Create(userId, request.ProductId);
            if (!wishlist.IsSuccess)
            {
                return new CreateWishlistCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { wishlist.Error }
                };
            }

            await wishlistRespository.AddAsync(wishlist.Value);

            return new CreateWishlistCommandResponse
            {
                Success = true,
                Wishlist = new CreateWishlistDto
                {
                    WishlistId = wishlist.Value.WishlistId,
                    UserId = wishlist.Value.UserId,
                    ProductId = wishlist.Value.ProductId
                }
            };
        }

    }
}

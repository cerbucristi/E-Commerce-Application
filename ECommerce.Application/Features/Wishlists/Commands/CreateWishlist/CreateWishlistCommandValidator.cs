using FluentValidation;

namespace   ECommerce.Application.Features.Wishlists.Commands.CreateWishlist
{
    public class CreateWishlistCommandValidator : AbstractValidator<CreateWishlistCommand>
    {
        public CreateWishlistCommandValidator()
        {
        }
    }
}

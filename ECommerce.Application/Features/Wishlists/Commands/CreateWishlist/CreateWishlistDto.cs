namespace ECommerce.Application.Features.Wishlists.Commands.CreateWishlist
{
    public class CreateWishlistDto
    {
        public Guid WishlistId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
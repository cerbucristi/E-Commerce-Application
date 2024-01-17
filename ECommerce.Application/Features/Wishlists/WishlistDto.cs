namespace ECommerce.Application.Features.Wishlists
{
    public class WishlistDto
    {
        public Guid WishlistId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

    }
}
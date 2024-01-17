using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Wishlist : AuditableEntity
    {
        private Wishlist(Guid userId, Guid productId)
        {
            WishlistId = Guid.NewGuid();
            UserId = userId;
            ProductId = productId;

        }

        public Guid WishlistId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }


        public static Result<Wishlist> Create(Guid userId, Guid productId)
        {
            if (userId == null)
            {
                return Result<Wishlist>.Failure("User Id is required.");
            }
            if (productId == null)
            {
                return Result<Wishlist>.Failure("Product Id is required.");
            }

            return Result<Wishlist>.Success(new Wishlist(userId,productId));
        }
    }
}

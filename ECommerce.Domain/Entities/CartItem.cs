using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class CartItem : AuditableEntity
    {
        private CartItem(Guid productId, int quantity)
        {
            CartItemId = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid CartItemId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public static Result<CartItem> Create(Guid productId, int quantity)
        {
            if (quantity < 1)
            {
                return Result<CartItem>.Failure("Quantity cannot be less than 1.");
            }
            if (productId == Guid.Empty)
            {
                return Result<CartItem>.Failure("Invalid product id.");
            }
            return Result<CartItem>.Success(new CartItem(productId, quantity));
        }
    }
}
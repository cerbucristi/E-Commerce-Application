using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class ShoppingCart : AuditableEntity
    {
        private ShoppingCart(Guid customerId)
        {
            ShoppingCartId = Guid.NewGuid();
            CustomerId = customerId;
            CartItems = new List<CartItem>();
        }

        public Guid ShoppingCartId { get; private set; }
        public Guid CustomerId { get; private set; }
        public List<CartItem> CartItems { get; private set; }

        public static Result<ShoppingCart> Create(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                return Result<ShoppingCart>.Failure("Invalid customer id.");
            }
            return Result<ShoppingCart>.Success(new ShoppingCart(customerId));
        }

        public void AddCartItem(CartItem cartItem)
        {
            CartItems.Add(cartItem);
        }
    }
}

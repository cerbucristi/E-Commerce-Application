using ECommerce.Domain.Common;
using System.Text.Json.Serialization;

namespace ECommerce.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {

        [JsonConstructor]
        private OrderItem(Guid productId, int quantity, decimal price)
        {
            OrderItemId = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid OrderItemId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public static Result<OrderItem> Create(Guid productId, int quantity, decimal price)
        {

            if (productId == Guid.Empty)
            {
                return Result<OrderItem>.Failure("Invalid product id.");
            }
            if (quantity < 1)
            {
                return Result<OrderItem>.Failure("Quantity cannot be less than 1.");
            }
            if (price <= 0)
            {
                return Result<OrderItem>.Failure("Price cannot be less than or equal to 0.");
            }
            return Result<OrderItem>.Success(new OrderItem(productId, quantity, price));
        }

        public decimal GetTotal()
        {
            return Quantity * Price;
        }
    }
}

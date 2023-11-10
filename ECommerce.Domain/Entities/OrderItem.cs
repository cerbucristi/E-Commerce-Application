using ECommerce.Domain.Common;
using System;

namespace ECommerce.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
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

        public static OrderItem Create(Guid productId, int quantity, decimal price)
        {
            return new OrderItem(productId, quantity, price);
        }

        public decimal GetTotal()
        {
            return Quantity * Price;
        }
    }
}

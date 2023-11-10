using ECommerce.Domain.Common;
using System;

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

        public static CartItem Create(Guid productId, int quantity)
        {
            // You can add additional validation here if needed.
            return new CartItem(productId, quantity);
        }
    }
}
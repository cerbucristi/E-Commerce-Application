using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;

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
            return Result<ShoppingCart>.Success(new ShoppingCart(customerId));
        }

        public void AddCartItem(CartItem cartItem)
        {
            CartItems.Add(cartItem);
        }
    }
}

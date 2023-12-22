using ECommerce.Domain.Entities;
using FluentAssertions;

namespace ECommerce.Domain.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void When_CreateShoppingCartIsCalled_Then_SuccessIsReturned()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            // Act
            var result = ShoppingCart.Create(customerId);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
        [Fact]
        public void When_CreateShoppingCartIsCalled_And_CustomerIdIsEmpty()
        {
            // Arrange
            // Act
            var result = ShoppingCart.Create(Guid.Empty);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_AddCartItemIsCalled()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var shoppingCart = ShoppingCart.Create(customerId).Value;
            var productId = Guid.NewGuid();
            var quantity = 1;
            var cartItem = CartItem.Create(productId, quantity).Value;
            // Act
            shoppingCart.AddCartItem(cartItem);
            // Assert
            shoppingCart.CartItems.Should().NotBeEmpty();
        }
    }
}

using ECommerce.Domain.Entities;
using FluentAssertions;
namespace ECommerce.Domain.Tests
{
    public class CartItemTests
    {
        [Fact]
        public void When_CreateCartItemIsCalled_And_ProductIdIsEmpty()
        {
               // Arrange
            var quantity = 1;
            // Act
            var result = CartItem.Create(Guid.Empty, quantity);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateCartItemIsCalled_And_QuantityIsLessThanOne()
        {
               // Arrange
            var productId = Guid.NewGuid();
            var quantity = 0;
            // Act
            var result = CartItem.Create(productId, quantity);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateCartItemIsCalled_Then_SuccessIsReturned()
        {
               // Arrange
            var productId = Guid.NewGuid();
            var quantity = 1;
            // Act
            var result = CartItem.Create(productId, quantity);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
        
    }
}

using ECommerce.Domain.Entities;
using FluentAssertions;
namespace ECommerce.Domain.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void When_CreateOrderItemIsCalled_And_QuantityIsLessThanOne()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var quantity = -10;
            var price = 10;
            // Act
            var result = OrderItem.Create(productId,price, quantity);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateOrderItemIsCalled_Then_SuccessIsReturned()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var quantity = 1;
            var price = 10;
            // Act
            var result = OrderItem.Create(productId,price, quantity);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
        [Fact]
        public void When_CreateOrderItemIsCalled_And_PriceIsLessThanZero()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var quantity = 1;
            var price = -10;
            // Act
            var result = OrderItem.Create(productId,price, quantity);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateOrderItemIsCalled_And_ProductIdIsEmpty()
        {
            // Arrange
            var productId = Guid.Empty;
            var quantity = 1;
            var price = 10;
            // Act
            var result = OrderItem.Create(productId,price, quantity);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_GetTotalIsCalled() { 
            // Arrange
            var productId = Guid.NewGuid();
            var quantity = 2;
            var price = 10;
            var orderItem = OrderItem.Create(productId,price, quantity).Value;
            // Act
            var total = orderItem.GetTotal();
            // Assert
            total.Should().Be(20);
        }
    }
}

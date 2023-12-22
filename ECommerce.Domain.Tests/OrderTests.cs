using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using FluentAssertions;
namespace ECommerce.Domain.Tests
{
    public class OrderTests
    {
        [Fact]
        public void When_CreateOrderIsCalled_And_CustomerIdIsEmpty()
        {
            //Arrange
            var customerId = Guid.Empty;
            //Act
            var result = Order.Create(customerId);
            //Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Invalid customer id.");
        }
        [Fact]
        public void When_CreateOrderIsCalled_Then_SuccessIsReturned()
        {
            //Arrange
            var customerId = Guid.NewGuid();
            //Act
            var result = Order.Create(customerId);
            //Assert
            result.IsSuccess.Should().BeTrue();
        }
        [Fact]
        public void When_AddOrderItemIsCalled_Then_OrderItemIsAdded()
        {
            //Arrange
            var customerId = Guid.NewGuid();
            var order = Order.Create(customerId).Value;
            var productId = Guid.NewGuid();
            var quantity = 1;
            var price = 10;
            var orderItem = OrderItem.Create(productId, price, quantity).Value;
            //Act
            order.AddOrderItem(orderItem);
            //Assert
            order.OrderItems.Should().Contain(orderItem);
        }
        [Fact]
        public void When_AddPaymentIsCalled_Then_PaymentIsAdded()
        {
            //Arrange
            var customerId = Guid.NewGuid();
            var order = Order.Create(customerId).Value;          
            var payment = Payment.Create(Guid.NewGuid(),"Cash", 100).Value;
            //Act
            order.AddPayment(payment);
            //Assert
            order.Payments.Should().Contain(payment);
        }
    }
}

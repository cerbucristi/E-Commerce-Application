using ECommerce.Domain.Entities;
using FluentAssertions;
namespace ECommerce.Domain.Tests
{
    public class PaymentTests
    {
        [Fact]
        public void When_CreatePaymentIsCalled_And_OrderIdIsEmpty()
        {
            // Arrange
            var paymentmethod = "Credit Card";
            var amount = 10;
            // Act
            var result = Payment.Create(Guid.Empty,paymentmethod,amount);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreatePaymentIsCalled_And_PaymentMethodIsEmpty()
        {
            // Arrange
            var paymentmethod = "";
            var amount = 10;
            // Act
            var result = Payment.Create(Guid.NewGuid(),paymentmethod,amount);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreatePaymentIsCalled_And_AmountIsLessThanZero()
        {
            // Arrange
            var paymentmethod = "Credit Card";
            var amount = -10;
            // Act
            var result = Payment.Create(Guid.NewGuid(),paymentmethod,amount);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreatePaymentIsCalled_Then_SuccessIsReturned()
        {
            // Arrange
            var paymentmethod = "Credit Card";
            var amount = 10;
            // Act
            var result = Payment.Create(Guid.NewGuid(),paymentmethod,amount);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }

    }
}

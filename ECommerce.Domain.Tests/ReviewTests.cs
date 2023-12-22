using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using FluentAssertions;
namespace ECommerce.Domain.Tests
{
    public class ReviewTests
    {
        
        [Fact]
        public void When_CreateReviesIsCalled_And_ReviewTextIsEmpty()
        {
            // Arrange
            var reviewText = string.Empty;
            var rating = 1;
            var productId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            // Act
            var result = Review.Create(reviewText, rating, productId, customerId);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateReviesIsCalled_And_RatingIsLessThanOne()
        {
            // Arrange
            var reviewText = "Test";
            var rating = 0;
            var productId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            // Act
            var result = Review.Create(reviewText, rating, productId, customerId);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateReviesIsCalled_And_RatingIsGreaterThanFive()
        {
            // Arrange
            var reviewText = "Test";
            var rating = 6;
            var productId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            // Act
            var result = Review.Create(reviewText, rating, productId, customerId);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateReviesIsCalled_Then_SuccessIsReturned()
        {
            // Arrange
            var reviewText = "Test";
            var rating = 1;
            var productId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            // Act
            var result = Review.Create(reviewText, rating, productId, customerId);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
        [Fact]
        public void When_CreateReviesIsCalled_And_ProductIdIsEmpty()
        {
            // Arrange
            var reviewText = "Test";
            var rating = 1;
            var productId = Guid.Empty;
            var customerId = Guid.NewGuid();
            // Act
            var result = Review.Create(reviewText, rating, productId, customerId);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateReviesIsCalled_And_CustomerIdIsEmpty()
        {
            // Arrange
            var reviewText = "Test";
            var rating = 1;
            var productId = Guid.NewGuid();
            var customerId = Guid.Empty;
            // Act
            var result = Review.Create(reviewText, rating, productId, customerId);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        
    }
}

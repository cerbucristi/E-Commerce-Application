using ECommerce.Domain.Entities;
using FluentAssertions;
namespace ECommerce.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void When_CreateProductIsCalled_And_ProductNameIsValid_Then_SuccessIsReturned()
        {
            // Arrange
            var productName = "Product Test";
            var productDescription = "Description Test";
            var productPrice = 10;
            var productQuantity = 1;
            var categoryId = Guid.NewGuid();
            var manufacturerId = Guid.NewGuid();
            // Act
            var result = Product.Create(productName, productDescription, productPrice, productQuantity, categoryId, manufacturerId);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
        [Fact]
        public void When_CreateProductIsNull_Then_FailureIsReturned()
        {
            // Arrange          
            // Act
            var result = Product.Create(null!, null!, 0, 0, Guid.Empty, Guid.Empty);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_SetDescriptionIsCalled() { 
            // Arrange
            var product = Product.Create("Product Test", "Description Test", 10, 1, Guid.NewGuid(), Guid.NewGuid()).Value;
            // Act
            product.SetDescription("Description Test 2");
            // Assert
            product.Description.Should().Be("Description Test 2");
        }

        [Fact]
        public void When_UpdateProductIsCalled()
        {
            // Arrange
            var product = Product.Create("Product Test", "Description Test", 10, 1, Guid.NewGuid(), Guid.NewGuid()).Value;
            // Act
            product.Update("Product Test 2", "Description Test 2", 20, 2, Guid.NewGuid(), Guid.NewGuid());
            // Assert
            product.ProductName.Should().Be("Product Test 2");
            product.Description.Should().Be("Description Test 2");  
            product.Price.Should().Be(20);
            product.StockQuantity.Should().Be(2);
        }   
    }
}

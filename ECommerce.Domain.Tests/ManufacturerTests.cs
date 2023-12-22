using ECommerce.Domain.Entities;
using FluentAssertions;
namespace ECommerce.Domain.Tests
{
    public class ManufacturerTests
    {
        [Fact]
        public void When_CreateManufacturerIsCalled_And_ManufacturerNameIsValid_Then_SuccessIsReturned()
        {
            // Arrange
            var manufacturerName = "Manufacturer Test";
            // Act
            var result = Manufacturer.Create(manufacturerName);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
        [Fact]
        public void When_CreateManufacturerIsNull_Then_FailureIsReturned()
        {
            // Arrange          
            // Act
            var result = Manufacturer.Create(null!);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_AttachPoductIsCalled_And_ProductsIsNull()
        {
            // Arrange
            var manufacturerName = "Manufacturer Test";
            var manufacturer = Manufacturer.Create(manufacturerName).Value;
            var category = Category.Create("Category Test").Value;
            var product = Product.Create("Product Test", "Description Test", 10, 1, category.CategoryId, manufacturer.ManufacturerId).Value;
            // Act
            manufacturer.AttachProduct(product);
            // Assert
            manufacturer.Products.Should().NotBeNull();
        }

        [Fact]
        public void When_AttachProductIsCalled_And_ProductIsNotNull()
        {
            // Arrange
            var manufacturerName = "Manufacturer Test";
            var manufacturer = Manufacturer.Create(manufacturerName).Value;
            var category = Category.Create("Category Test").Value;
            var product = Product.Create("Product Test", "Description Test", 10, 1, category.CategoryId, manufacturer.ManufacturerId).Value;
            // Act
            manufacturer.AttachProduct(product);
            // Assert
            manufacturer.Products.Should().NotBeNull();
        }
        [Fact]
        public void When_UpdateManufacturerIsCalled()
        {
            // Arrange
            var manufacturerName = "Manufacturer Test";
            var manufacturer = Manufacturer.Create(manufacturerName).Value;
            // Act
            manufacturer.Update("Manufacturer Test 2");
            // Assert
            manufacturer.ManufacturerName.Should().Be("Manufacturer Test 2");
        }
        [Fact]
        public void When_UpdateManufacturerIsCalled_And_ManufacturerNameIsWhiteSpace()
        {
            // Arrange
            var manufacturerName = "Manufacturer Test";
            var manufacturer = Manufacturer.Create(manufacturerName).Value;
            // Act
            manufacturer.Update(" ");
            // Assert
            manufacturer.ManufacturerName.Should().Be("Manufacturer Test");
        }
        
    }
}

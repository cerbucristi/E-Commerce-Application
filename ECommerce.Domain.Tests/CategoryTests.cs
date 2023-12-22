using ECommerce.Domain.Entities;
using FluentAssertions;

namespace ECommerce.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void When_CreateCategoryIsCalled_And_CategoryNameIsValid_Then_SuccessIsReturned()
        {
            // Arrange
            var categoryName = "Category Test";

            // Act
            var result = Category.Create(categoryName);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_CreateCategoryIsNull_Then_FailureIsReturned()
        {
            // Arrange          
            // Act
            var result = Category.Create(null!);

            // Assert
            result.IsSuccess.Should().BeFalse(); 
        }
        [Fact]
        public void When_AttachPoductIsCalled_And_ProductsIsNull()
        {
            // Arrange
            var categoryName = "Category Test";
            var manufacturer = Manufacturer.Create("Manufacturer Test").Value;
            var category = Category.Create(categoryName).Value;
            var product = Product.Create("Product Test", "Description Test" , 10, 1, category.CategoryId,manufacturer.ManufacturerId).Value;

            // Act
            category.AttachProduct(product);

            // Assert
            category.Products.Should().NotBeNull();
        }

        [Fact]
        public void When_AttachProductIsCalled_And_ProductIsNotNull() {
            // Arrange
            var categoryName = "Category Test";
            var manufacturer = Manufacturer.Create("Manufacturer Test").Value;
            var category = Category.Create(categoryName).Value;
            var product = Product.Create("Product Test", "Description Test" , 10, 1, category.CategoryId,manufacturer.ManufacturerId).Value;

            // Act
            category.AttachProduct(product);

            // Assert
            category.Products.Should().NotBeNull();
        }
        [Fact]
        public void When_UdateCategoryIsCalled() {
            // Arrange
            Category category = Category.Create("Category Test").Value;

            // Act
            category.Update("Category Test Updated");

            // Assert
            category.CategoryName.Should().Be("Category Test Updated");
        }
    }
}
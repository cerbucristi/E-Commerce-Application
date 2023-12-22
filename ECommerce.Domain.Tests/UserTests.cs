using ECommerce.Domain.Entities;
using FluentAssertions;
using Newtonsoft.Json.Bson;
namespace ECommerce.Domain.Tests
{
    public class UserTests
    {
        [Fact]
        public void When_CreateUserIsCalled_And_EmailIsNullOrEmpty()
        {
            var result = User.Create(null!,"test", "test");
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateUserIsCalled_And_PasswordIsInvalid()
        {
            // Arrange        
            var username = "test";
            var email = "test";
         
            // Act
            var result = User.Create(username, email, null!);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateUserIsCalled_And_UsernameIsInvalid()
        {
            // Arrange        
            var email = "test";
            var password = "test";
            // Act
            var result = User.Create(null!, email, password);
            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_CreateUserIsCalled_And_SuccessIsReturned()
        {
            // Arrange        
            var username = "test";
            var email = "test";
            var password = "test";
            // Act
            var result = User.Create(username, email, password);
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}

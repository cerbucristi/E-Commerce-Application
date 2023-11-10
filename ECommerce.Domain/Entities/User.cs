using ECommerce.Domain.Common;
using System;

namespace ECommerce.Domain.Entities
{
    public class User : AuditableEntity
    {
        private User(string username, string email, string password)
        {
            UserId = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
        }

        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public static Result<User> Create(string username, string email, string password)
        {
            // You can add additional validation here if needed.
            return Result<User>.Success(new User(username, email, password));
        }
    }
}
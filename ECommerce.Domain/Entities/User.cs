using ECommerce.Domain.Common;

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
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return Result<User>.Failure("Username, email and password are required.");
            }
            return Result<User>.Success(new User(username, email, password));
        }
    }
}
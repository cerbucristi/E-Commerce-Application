using Microsoft.AspNetCore.Identity;

namespace ECommerce.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserName { get; set; }

        public string? Id { get; set; }

        public string? Email { get; set; }
    }
}

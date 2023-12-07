using Microsoft.AspNetCore.Identity;

namespace ECommerce.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}

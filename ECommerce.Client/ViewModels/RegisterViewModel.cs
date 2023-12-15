using System.Text.Json;
using System.Text.RegularExpressions;

namespace ECommerce.Client.ViewModels;

public class RegisterViewModel
{
    public bool IsCompleted()
    {
        return !(
            string.IsNullOrEmpty(this.Email) ||
            string.IsNullOrEmpty(this.Username) ||
            string.IsNullOrEmpty(this.Password) ||
            string.IsNullOrEmpty(this.PasswordCheck)
        );

    }
        
    public bool IsValidEmail()
    {
        string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";    
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);    
        return regex.IsMatch(this.Email);
    }
        
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string PasswordCheck { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
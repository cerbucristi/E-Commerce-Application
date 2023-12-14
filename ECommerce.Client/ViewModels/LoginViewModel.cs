namespace ECommerce.Client.ViewModels;

public class LoginViewModel
{
    public bool IsCompleted()
    {
        return !(
            string.IsNullOrEmpty(this.Email) ||
            string.IsNullOrEmpty(this.Password)
        );
    }
    
    public string Email { get; set; }
    public string Password { get; set; }
}
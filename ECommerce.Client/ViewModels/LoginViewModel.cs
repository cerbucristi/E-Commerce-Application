namespace ECommerce.Client.ViewModels;

public class LoginViewModel
{
    public bool IsCompleted()
    {
        return !(
            string.IsNullOrEmpty(this.Username) ||
            string.IsNullOrEmpty(this.Password)
        );
    }
    
    public string Username { get; set; }
    public string Password { get; set; }
}
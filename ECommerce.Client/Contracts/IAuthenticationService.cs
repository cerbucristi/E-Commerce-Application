using ECommerce.Client.ViewModels;

namespace ECommerce.Client.Contracts
{
    public interface IAuthenticationService
    {
        Task Login(LoginViewModel loginRequest);
        Task Register(RegisterViewModel registerRequest);
        Task Logout();
    }
}

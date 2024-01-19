namespace ECommerce.Client.Contracts
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync();
        Task RemoveTokenAsync();
        Task SetTokenAsync(string token);
        Task<string> GetRoleFromJwtAsync();
    }
}

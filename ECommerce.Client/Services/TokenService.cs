using Blazored.LocalStorage;
using ECommerce.Client.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerce.Client.Services
{

    public class TokenService : ITokenService
    {
        private const string TOKEN = "token";
        private readonly ILocalStorageService localStorageService;

        public TokenService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task SetTokenAsync(string token)
        {
            await localStorageService.SetItemAsync(TOKEN, token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await localStorageService.GetItemAsync<string>(TOKEN);
        }

        public async Task RemoveTokenAsync()
        {
            await localStorageService.RemoveItemAsync(TOKEN);
        }
        public async Task<string> GetRoleFromJwtAsync()
        {
            var jwt = await GetTokenAsync();

            if (string.IsNullOrEmpty(jwt))
            {
                return null;
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt) as JwtSecurityToken;

            if (jsonToken == null || !jsonToken.Header.Alg.Equals("HS256", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var roleClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == "role");

            return roleClaim?.Value;
        }
    }
}

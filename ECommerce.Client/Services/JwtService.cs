    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
namespace ECommerce.Client.Services
{ 
    public static class JwtParser
    {
        public static string GetRoleFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt) as JwtSecurityToken;
            if (jsonToken == null || !jsonToken.Header.Alg.Equals("HS256", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid JWT");
            }

            var roleClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            return roleClaim?.Value;
        }
    }

}

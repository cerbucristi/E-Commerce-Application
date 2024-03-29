﻿using ECommerce.Application.Contracts.Interfaces;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!;
        public ClaimsPrincipal GetCurrentClaimsPrincipal()
        {
            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null)
            {
                return httpContextAccessor.HttpContext.User;
            }

            return null!;
        }

        public string GetCurrentUserId()
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }
        public string GetCurrentUserEmail()
        {
            var userEmailClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email);
            return userEmailClaim?.Value;
        }

        public bool IsUserAuthorized()
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null || user?.Identity?.IsAuthenticated != true)
            {
                return false;
            }
            return true;
        }
    }
}

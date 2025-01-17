using Core.Application.Common.Interfaces.Services;
using Core.Domain.UserAggregate;
using Core.Domain.UserAggregate.ValueObjects;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Application.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserId GetUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                throw new ApplicationException("HttpContext is null. Make sure the request is within a valid HTTP pipeline.");

            var id = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(id))
                throw new ApplicationException("User ID (sub) is missing in the JWT token.");

            if (!Guid.TryParse(id, out var userId))
                throw new ApplicationException("User ID (sub) in the JWT token is not a valid GUID.");

            return UserId.Create(userId);
        }

        public UserRole GetUserRole()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                throw new ApplicationException("HttpContext is null. Make sure the request is within a valid HTTP pipeline.");

            var roleString = httpContext.User.FindFirstValue(ClaimTypes.Role);

            if (string.IsNullOrEmpty(roleString))
                throw new ApplicationException("Role claim is missing or empty in the HTTP context.");

            if (!Enum.TryParse(roleString, true, out UserRole role))
                throw new ApplicationException($"Invalid role value: '{roleString}'. Unable to map it to UserRole enum.");

            return role;
        }
    }
}
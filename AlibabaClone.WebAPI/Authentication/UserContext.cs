using AlibabaClone.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace AlibabaClone.WebAPI.Authentication
{
    
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetUserId()
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (long.TryParse(userIdStr, out var userId))
                return userId;
            throw new UnauthorizedAccessException("User ID not found in token.");
        }
    }
}

using AlibabaClone.Application.DTOs.Authentication;

namespace AlibabaClone.WebAPI.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateToken(AuthResponseDto authResponseDto);
    }
}

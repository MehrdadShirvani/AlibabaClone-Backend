using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.Authentication;

namespace AlibabaClone.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(AuthResponseDto authResponseDto);
    }
}

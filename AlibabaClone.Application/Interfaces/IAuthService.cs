using AlibabaClone.Application.DTOs.Authentication;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDto>> RegisterAsync(RegisterRequestDto request);
        Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto request);
    }
}

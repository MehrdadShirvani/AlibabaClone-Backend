using AlibabaClone.Application.DTOs.Account;

namespace AlibabaClone.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(AccountDTO accountDTO);
    }
}

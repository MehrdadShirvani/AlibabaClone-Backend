using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Result<ProfileDto>> GetProfileAsync(long accountId);
        Task<Result<List<TicketOrderSummaryDto>>> GetTravels(long accountId);
    }
}

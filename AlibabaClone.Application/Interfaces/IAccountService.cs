using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Result<ProfileDto>> GetProfileAsync(long accountId);
        Task<Result<List<TicketOrderSummaryDto>>> GetTravels(long accountId);
        Task<Result<List<TravelerTicketDto>>> GetTicketOrderTravelersDetails(long accountId, long ticketOrderId);
        Task<Result<List<TransactionDto>>> GetAccountTransactions(long accountId);
        Task<Result<long>> UpdateEmailAsync(long accountId, string newEmail);
        Task<Result<long>> UpdatePasswordAsync(long accountId, string oldPassword, string newPassword);
        Task<Result<long>> UpsertBankAccountDetailAsync(long accountId, UpsertBankAccountDetailDto dto);
        Task<Result<List<PersonDto>>> GetPeople(long accountId);
        Task<Result<long>> TopUpAccount(long accountId, TopUpDto topUpDto);
        Task<Result<long>> PayForTicketOrderAsync(long accountId, long ticketOrderId, decimal baseAmount, decimal finalAmount, long? couponId);
    }
}

using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.AccountAggregates;

namespace AlibabaClone.Application.Interfaces
{
    public interface IPersonService
    {
        Task<Result<long>> UpsertAccountPersonAsync(long accountId, PersonDto dto); // Returns PersonId
        Task<Result<long>> UpsertPersonAsync(long accountId, PersonDto dto); // Returns PersonId
    }
}

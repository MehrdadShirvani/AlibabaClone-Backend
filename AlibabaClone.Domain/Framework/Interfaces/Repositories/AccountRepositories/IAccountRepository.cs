using AlibabaClone.Domain.Aggregates.AccountAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories
{
    public interface IAccountRepository : IRepository<Account, long>
    {
        Task<Account> GetByPhoneNumberAsync(string phoneNumber);
        Task AddAccountRoleAsync(AccountRole accountRole);
        Task<Account> GetProfileAsync(long accountId);
    }
}

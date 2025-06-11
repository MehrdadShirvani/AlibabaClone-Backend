using AlibabaClone.Domain.Aggregates.AccountAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories
{
    public interface IBankAccountDetailRepository : IRepository<BankAccountDetail, long>
    {
        Task<BankAccountDetail> GetByAccountIdAsync(long accountId);
    }
}

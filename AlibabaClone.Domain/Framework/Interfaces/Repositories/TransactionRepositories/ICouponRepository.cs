using AlibabaClone.Domain.Aggregates.TransactionAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories
{
    public interface ICouponRepository : IRepository<Coupon, long> 
    {
        Task<Coupon?> GetByCodeAsync(string code);
        Task<int> GetTotalUsagesAsync(string code);
        Task<int> GetUsagesByAccountAsync(string code, long accountId);
    }
}

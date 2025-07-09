using AlibabaClone.Domain.Aggregates.TransactionAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories
{
    public interface ITransactionRepository : IRepository<Transaction, long>
    {
        public Task<List<Transaction>> GetAllByAccountIdAsync(long buyerId);
    }
}

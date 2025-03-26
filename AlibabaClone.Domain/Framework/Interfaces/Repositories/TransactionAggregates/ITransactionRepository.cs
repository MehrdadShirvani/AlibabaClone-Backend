using AlibabaClone.Domain.Aggregates.TransactionAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionAggregates
{
    public interface ITransactionRepository : IRepository<Transaction, long>
    {

    }
}

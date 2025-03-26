using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransactionAggregates
{
    public class TransactionRepository :
        BaseRepository<ApplicationDBContext, Transaction, long>,
        ITransactionRepository
    {
        public TransactionRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

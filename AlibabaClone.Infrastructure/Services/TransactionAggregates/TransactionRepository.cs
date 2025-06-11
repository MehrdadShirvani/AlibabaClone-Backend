using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransactionAggregates
{
    public class TransactionRepository :
        BaseRepository<ApplicationDBContext, Transaction, long>,
        ITransactionRepository
    {
        public TransactionRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Transaction>> GetAllByAccountIdAsync(long buyerId)
        {
            var list = await DbContext.Transactions
                               .Include(x => x.TicketOrder)
                               .Include(x => x.TransactionType)
                               .Where(x => x.AccountId == buyerId).ToListAsync();
            return list;
        }
    }
}

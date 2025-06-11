using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class BankAccountDetailRepository :
        BaseRepository<ApplicationDBContext, BankAccountDetail, long>,
        IBankAccountDetailRepository
    {
        public BankAccountDetailRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<BankAccountDetail> GetByAccountIdAsync(long accountId)
        {
            return await DBSet.FirstOrDefaultAsync(x => x.AccountId == accountId);
        }
    }
}

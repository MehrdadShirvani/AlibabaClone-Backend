using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class AccountRepository :
        BaseRepository<ApplicationDBContext, Account, long>,
        IAccountRepository
    {
        public AccountRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

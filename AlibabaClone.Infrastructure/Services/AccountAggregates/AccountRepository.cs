using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class AccountRepository :
        BaseRepository<ApplicationDBContext, Account, long>,
        IAccountRepository
    {
        public AccountRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<Account> GetByPhoneNumberAsync(string phoneNumber)
        {
            var user = await DbContext.Accounts.Include(x => x.AccountRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            return user;
        }
    }
}

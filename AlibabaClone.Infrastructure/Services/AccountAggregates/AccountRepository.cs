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


        public async Task AddAccountRoleAsync(AccountRole accountRole)
        {
            await DbContext.AccountRoles.AddAsync(accountRole);
        }
        public async Task<Account> GetByPhoneNumberAsync(string phoneNumber)
        {
            var user = await DbContext.Accounts.Include(x => x.AccountRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            return user;
        }

        public async Task<Account?> GetProfileAsync(long accountId)
        {
            return await DbContext.Accounts
                                 .Include(x => x.BankAccountDetail)
                                  .Include(x => x.Person)
                                  .FirstOrDefaultAsync(x => x.Id == accountId);
        }

        public async Task<Account?> GetByEmailAsync(string email)
        {
            return await DbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

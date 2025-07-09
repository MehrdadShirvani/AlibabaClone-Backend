using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class PersonRepository :
        BaseRepository<ApplicationDBContext, Person, long>,
        IPersonRepository
    {
        public PersonRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Person>> GetAllByCreatorAccountIdAsync(long accountId)
        {
            return await DBSet.Where(x => x.CreatorAccountId == accountId).ToListAsync();
        }
    }
}

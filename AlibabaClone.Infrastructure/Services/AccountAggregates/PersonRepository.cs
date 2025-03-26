using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class PersonRepository :
        BaseRepository<ApplicationDBContext, Person, long>,
        IPersonRepository
    {
        public PersonRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

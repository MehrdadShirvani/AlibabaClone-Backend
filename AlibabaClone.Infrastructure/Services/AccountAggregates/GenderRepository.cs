using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class GenderRepository :
        BaseRepository<ApplicationDBContext, Gender, short>,
        IGenderRepository
    {
        public GenderRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

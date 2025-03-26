using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class CityRepository :
        BaseRepository<ApplicationDBContext, City, int>,
        ICityRepository
    {
        public CityRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

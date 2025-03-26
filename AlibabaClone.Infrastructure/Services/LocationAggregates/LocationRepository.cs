using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class LocationRepository :
        BaseRepository<ApplicationDBContext, Location, int>,
        ILocationRepository
    {
        public LocationRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

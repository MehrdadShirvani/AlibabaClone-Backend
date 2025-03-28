using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountAggregates
{
    public class LocationTypeRepository :
        BaseRepository<ApplicationDBContext, LocationType, short>,
        ILocationTypeRepository
    {
        public LocationTypeRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

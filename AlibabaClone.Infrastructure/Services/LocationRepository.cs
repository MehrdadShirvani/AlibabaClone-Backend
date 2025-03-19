using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using AlibabaClone.Infrastructure.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Services
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

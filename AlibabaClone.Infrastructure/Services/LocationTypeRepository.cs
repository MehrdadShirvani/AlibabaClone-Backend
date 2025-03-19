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
    public class LocationTypeRepository :
        BaseRepository<ApplicationDBContext, LocationType, short>,
        ILocationTypeRepository
    {
        public LocationTypeRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

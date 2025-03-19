using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using AlibabaClone.Infrastructure.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Services
{
    public class VehicleRepository :
        BaseRepository<ApplicationDBContext, Vehicle, int>,
        IVehicleRepository
    {
        public VehicleRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

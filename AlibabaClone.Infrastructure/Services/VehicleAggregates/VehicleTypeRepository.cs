using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.VehicleAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.VehicleAggregates
{
    public class VehicleTypeRepository :
        BaseRepository<ApplicationDBContext, VehicleType, short>,
        IVehicleTypeRepository
    {
        public VehicleTypeRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

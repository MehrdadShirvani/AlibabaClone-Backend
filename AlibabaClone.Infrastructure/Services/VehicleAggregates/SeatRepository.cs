using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.VehicleRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.VehicleAggregates
{
    public class SeatRepository :
        BaseRepository<ApplicationDBContext, Seat, long>,
        ISeatRepository
    {
        public SeatRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

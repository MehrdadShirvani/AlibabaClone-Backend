using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.VehicleRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.VehicleAggregates
{
    public class SeatRepository :
        BaseRepository<ApplicationDBContext, Seat, long>,
        ISeatRepository
    {
        public SeatRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Seat>> GetSeatsByVehicleId(long vehicleId)
        {
            return await DBSet.Include(x => x.Vehicle)
                              .Include(x => x.Tickets).ThenInclude(x => x.Traveler)
                              .Where(x => x.VehicleId == vehicleId).ToListAsync();
        }
    }
}

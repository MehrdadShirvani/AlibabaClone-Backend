using AlibabaClone.Domain.Aggregates.VehicleAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.VehicleRepositories
{
    public interface ISeatRepository : IRepository<Seat, long>
    {
        Task<List<Seat>> GetSeatsByVehicleId(long transportationId);
    }
}

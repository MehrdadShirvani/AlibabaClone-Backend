using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories
{
    public interface ITransportationRepository : IRepository<Transportation, long>
    {
        Task<IEnumerable<Transportation>> SearchTransportationsAsync(
            short? vehicleTypeId,
            int? fromCityId,
            int? toCityId, 
            DateTime? startDate, 
            DateTime? endDate);
    }
}

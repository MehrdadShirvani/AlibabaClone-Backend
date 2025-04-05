﻿using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories
{
    public interface ITransportationRepository : IRepository<Transportation, long>
    {
        Task<List<Transportation>> SearchTransportationsAsync(int? fromCityId, int? toCityId, DateTime? startDate, DateTime? endDate);
    }
}

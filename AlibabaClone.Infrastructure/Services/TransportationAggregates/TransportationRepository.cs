using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransportationAggregates
{
    public class TransportationRepository :
        BaseRepository<ApplicationDBContext, Transportation, long>,
        ITransportationRepository
    {
        public TransportationRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Transportation>> SearchTransportationsAsync(int? fromCityId, int? toCityId, DateTime? startDate, DateTime? endDate)
        {
            var query = DbContext.Transportations.Include(x => x.FromLocation).Include(x => x.ToLocation).AsQueryable();
            
            query = query.Where(x => fromCityId == null || x.FromLocation.CityId == fromCityId.Value);
            query = query.Where(x => toCityId == null || x.ToLocation.CityId == toCityId.Value);
            query = query.Where(x => startDate == null || x.StartDateTime.Date == startDate.Value.Date);
            query = query.Where(x => endDate == null || x.EndDateTime.Date == endDate.Value.Date);
            query = query.Include(x => x.FromLocation).ThenInclude(x => x.City);
            query = query.Include(x => x.ToLocation).ThenInclude(x => x.City);
            return await query.Include(x => x.Company).ToListAsync();
        }
    }
}

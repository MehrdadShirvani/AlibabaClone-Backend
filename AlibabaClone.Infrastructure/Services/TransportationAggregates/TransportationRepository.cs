using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationAggregates
{
    public class TransportationRepository :
        BaseRepository<ApplicationDBContext, Transportation, long>,
        ITransportationRepository
    {
        public TransportationRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

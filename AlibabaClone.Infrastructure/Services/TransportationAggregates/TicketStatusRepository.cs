using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationAggregates
{
    public class TicketStatusRepository :
        BaseRepository<ApplicationDBContext, TicketStatus, short>,
        ITicketStatusRepository
    {
        public TicketStatusRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

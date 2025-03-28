using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationAggregates
{
    public class TicketRepository :
        BaseRepository<ApplicationDBContext, Ticket, long>,
        ITicketRepository
    {
        public TicketRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

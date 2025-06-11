using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransportationAggregates
{
    public class TicketRepository :
        BaseRepository<ApplicationDBContext, Ticket, long>,
        ITicketRepository
    {
        public TicketRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Ticket>> GetAllTicketsByTicketOrderId(long ticketOrderId)
        {
            var list = await DbContext.Tickets
                                .Include(x => x.Traveler)
                                .Include(x => x.TicketStatus)
                                .Include(x => x.Companion)
                                .Include(x => x.Seat)
                                .Include(x => x.TicketOrder)
                                .Where(x => x.TicketOrderId == ticketOrderId).ToListAsync();
            return list;
        }
    }
}

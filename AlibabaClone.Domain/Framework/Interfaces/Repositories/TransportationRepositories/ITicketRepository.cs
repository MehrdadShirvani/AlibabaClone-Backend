using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories
{
    public interface ITicketRepository : IRepository<Ticket, long>
    {
        public Task<List<Ticket>> GetAllTicketsByTicketOrderId(long ticketOrderId);
    }
}

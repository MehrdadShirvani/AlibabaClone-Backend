using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories
{
    public interface ITicketOrderRepository : IRepository<TicketOrder, long>
    {
        public Task<List<TicketOrder>> GetAllByBuyerId(long buyerId);
    }
}

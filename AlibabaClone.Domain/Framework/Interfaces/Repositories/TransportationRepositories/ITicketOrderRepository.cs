using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories
{
    public interface ITicketOrderRepository : IRepository<TicketOrder, long>
    {
        Task<List<TicketOrder>> GetAllByBuyerId(long buyerId);
        Task<TicketOrder> FindAndLoadAllDetails(long id);
    }
}

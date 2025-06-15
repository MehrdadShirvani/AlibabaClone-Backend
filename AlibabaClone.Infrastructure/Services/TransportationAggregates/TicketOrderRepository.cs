using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransportationAggregates
{
    public class TicketOrderRepository :
        BaseRepository<ApplicationDBContext, TicketOrder, long>,
        ITicketOrderRepository
    {
        public TicketOrderRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        
        }

        public async Task<List<TicketOrder>> GetAllByBuyerId(long buyerId)
        {
            var list = await DbContext.TicketOrders
                                .Include(x => x.Transaction)
                                .Include(x => x.Transportation).ThenInclude(x=>x.FromLocation)
                                .Include(x => x.Transportation).ThenInclude(x => x.ToLocation)
                                .Include(x => x.Transportation).ThenInclude(x => x.Company)
                                .Include(x => x.Transportation).ThenInclude(x => x.Vehicle)
                                .Where(x => x.BuyerId == buyerId).ToListAsync();
            return list;
        }
    }
}

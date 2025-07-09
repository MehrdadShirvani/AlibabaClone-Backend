using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
    public class TicketStatus : Entity<short>
    {
        public string Title { get; set; }
    }
}

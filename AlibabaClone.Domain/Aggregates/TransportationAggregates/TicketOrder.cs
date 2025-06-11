using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
    public class TicketOrder : Entity<long>
    {
        public long TransportationId { get; set; }
        public long BuyerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SerialNumber { get; protected set; }
        public string? Description { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual Transportation Transportation { get; set; }
        public virtual Account Buyer { get; set; }
    }
}

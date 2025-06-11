using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class Transaction :Entity<long>
    {
        public short TransactionTypeId { get; set; }    
        public long? TicketId { get; set; }
        public decimal BaseAmount { get; set; }  
        public decimal FinalAmount { get; set; }  
        public string SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? CouponId { get; set; }
        public string? Description { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}

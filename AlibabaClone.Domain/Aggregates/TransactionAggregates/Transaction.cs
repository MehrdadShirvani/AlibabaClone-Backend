using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class Transaction : Entity<long>
    {
        public short TransactionTypeId { get; set; }    
        public long AccountId{ get; set; }
        public long? TicketOrderId { get; set; }
        public decimal BaseAmount { get; set; }  
        public decimal FinalAmount { get; set; }  
        public required string SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? CouponId { get; set; }
        public string? Description { get; set; }

        public virtual Account Account { get; set; }
        public virtual Coupon? Coupon{ get; set; }
        public virtual TicketOrder? TicketOrder { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}

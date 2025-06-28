using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class Coupon : Entity<long>
    {
        public string Code { get; set; } 
        public decimal MaxDiscountAmount { get; set; }           
        public decimal? DiscountPercentage { get; set; }      // percentage-based
        public DateTime ExpiryDate { get; set; }
        public int MaxUsages { get; set; }               
        public int MaxUsagesPerAccount { get; set; }        
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Transaction> Transactions { get; set; }

        public bool IsExpired() => ExpiryDate < DateTime.UtcNow;

        
    }

}

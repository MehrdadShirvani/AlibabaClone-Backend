using AlibabaClone.Domain.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class Coupon : Entity<long>
    {
        public string Code { get; set; } 
        public decimal MaxDiscountAmount { get; set; }           
        public decimal? DiscountPercentage { get; set; }      // percentage-based
        public DateTime ExpiryDate { get; set; }
        public int MaxUsages { get; set; } = 1;               
        public int MaxUsagesPerAccount { get; set; } = 1;        
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Transaction> Transactions { get; set; }
    }

}

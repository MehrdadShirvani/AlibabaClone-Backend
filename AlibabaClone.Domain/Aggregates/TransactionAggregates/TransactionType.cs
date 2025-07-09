using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class TransactionType : Entity<short>
    {
        public string Title { get; set; }
    }
}

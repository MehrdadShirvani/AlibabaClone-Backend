using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Gender : Entity<short>
    {
        public required string Title { get; set; }
    }
}

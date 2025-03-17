using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Account : Entity<long>
    {
        public required string PhoneNumber { get; set; }
        public required string Password { set; get; }
        public string? Email { get; set; }
        public long? PersonId { get; set; }

        public virtual Person? Person { get; set; }
    }
}

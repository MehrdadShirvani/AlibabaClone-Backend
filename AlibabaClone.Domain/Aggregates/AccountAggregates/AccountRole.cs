namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class AccountRole
    {
        public long AccountId { get; set; }
        public short RoleId { get; set; }    

        public virtual Role Role { get; set; }
        public virtual Account Account{ get; set; }

    }
}

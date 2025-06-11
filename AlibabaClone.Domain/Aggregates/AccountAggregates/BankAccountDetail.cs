using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class BankAccountDetail : Entity<long>
    {
        public long AccountId { get; set; }  
        public string BankName { get; set; }
        public string CardNumber { get; set; }
        public string IBAN { get; set; }
        public string BankAccountNumber { get; set; }
        
        public Account Account { get; set; }
    }
}

using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Account : Entity<long>
    {
        public required string PhoneNumber { get; set; }
        public required string Password { set; get; }
        public string? Email { get; set; }
        public long? PersonId { get; set; }
        public decimal CurrentBalance { get; private set; }


        public virtual Person? Person { get; set; }
        public virtual BankAccountDetail? BankAccountDetail { get; set; }
        public virtual ICollection<Ticket> BoughtTickets { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }


        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Amount must be positive.");

            CurrentBalance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > CurrentBalance)
                throw new InvalidOperationException("Invalid withdrawal amount.");

            CurrentBalance -= amount;
        }

    }
}

using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Person : Entity<long>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdNumber { get; set; }
        
        public DateTime Birthdate { get; set; } 
        public short GenderId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? EnglishFirstName { get; set; }
        public string? EnglishLastName { get; set; }
        public long CreatorAccountId { get; set; }  

        public virtual Gender Gender { get; set; }
        public virtual Account CreatorAccount { get; set; }
        public virtual ICollection<Ticket> TraveledTickets { get; set; }
    }
}

using AlibabaClone.Domain.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Person : Entity<long>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdNumber { get; set; }
        //TODO: need to convert this to date in configuration
        public DateTime Birthdate { get; set; } 
        public byte GenderId { get; set; }
        public string? PassportNumber { get; set; }
        public string? EnglishFirstName { get; set; }
        public string? EnglishLastName { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}

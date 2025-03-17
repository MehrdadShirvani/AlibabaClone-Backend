using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class AccountRole
    {
        public long AccountId { get; set; }
        public byte RoleId { get; set; }    
    }
}

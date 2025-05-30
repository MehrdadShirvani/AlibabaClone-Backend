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
        public short RoleId { get; set; }    

        public virtual Role Role { get; set; }
        public virtual Account Account{ get; set; }

    }
}

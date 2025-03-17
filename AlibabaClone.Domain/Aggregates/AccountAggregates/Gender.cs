using AlibabaClone.Domain.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Gender : Entity<short>
    {
        public required string Title { get; set; }
    }
}

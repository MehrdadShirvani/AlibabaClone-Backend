using AlibabaClone.Domain.Aggregates.AccountAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person, long>
    {

    }
}

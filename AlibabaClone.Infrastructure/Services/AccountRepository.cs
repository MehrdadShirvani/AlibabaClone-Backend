using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using AlibabaClone.Infrastructure.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Services
{
    public class AccountRepository :
        BaseRepository<ApplicationDBContext, Account, long>,
        IAccountRepository
    {
        public AccountRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

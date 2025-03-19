using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using AlibabaClone.Infrastructure.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Services
{
    public class TransactionRepository :
        BaseRepository<ApplicationDBContext, Transaction, long>,
        ITransactionRepository
    {
        public TransactionRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

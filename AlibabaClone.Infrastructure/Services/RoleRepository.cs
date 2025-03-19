using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.CompanyAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using AlibabaClone.Infrastructure.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Services
{
    public class CompanyRepository :
        BaseRepository<ApplicationDBContext, Company, int>,
        ICompanyRepository
    {
        public CompanyRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}

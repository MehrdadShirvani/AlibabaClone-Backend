using AlibabaClone.Domain.Aggregates.CompanyAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.CompanyAggregates;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.CompanyAggregates
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

using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransactionAggregates
{
    public class CouponRepository : BaseRepository<ApplicationDBContext, Coupon, long>,
                                    ICouponRepository
    {
        public CouponRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Coupon?> GetByCodeAsync(string code)
        {
            return await DBSet.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<int> GetTotalUsagesAsync(string code)
        {
            var coupon = await DBSet.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Code == code);
            if(coupon == null) return -1;
            return coupon.Transactions.Count();
        }

        public async Task<int> GetUsagesByAccountAsync(string code, long accountId)
        {
            var coupon = await DBSet.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Code == code);
            if (coupon == null) return -1;
            return coupon.Transactions.Where(x => x.AccountId == accountId).Count();
        }
    }
}

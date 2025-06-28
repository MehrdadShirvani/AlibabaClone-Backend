using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AutoMapper.Internal.Mappers;

namespace AlibabaClone.Application.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IAccountRepository _accountRepository;
        public CouponService(ICouponRepository couponRepository, IAccountRepository accountRepository)
        {
            _couponRepository = couponRepository;
            _accountRepository = accountRepository;
        }
        public async Task<Result<DiscountDto>> ValidateCouponAsync(long accountId, CouponValidationRequestDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) 
            {
                return Result<DiscountDto>.Error(null, "Account Not Found");
            }
            Coupon coupon = new Coupon();
            try
            {
                coupon = await _couponRepository.GetByCodeAsync(dto.Code);
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                string a = "";
            }
            if (coupon == null)
            {
                return Result<DiscountDto>.Success(new DiscountDto 
                {
                    IsValid = false,
                    DiscountAmount = 0,
                    Message = "Coupon not found"
                });
            }

            int totalUsages = await _couponRepository.GetTotalUsagesAsync(dto.Code);
            int accountUsages = await _couponRepository.GetUsagesByAccountAsync(dto.Code, accountId); ;

            string error = CanBeUsedByAccount(coupon, accountUsages, totalUsages);
            if (!string.IsNullOrEmpty(error))
            {
                return Result<DiscountDto>.Success(new DiscountDto
                {
                    IsValid = false,
                    DiscountAmount = 0,
                    Message = error
                });
            }
            var discountAmount = coupon.MaxDiscountAmount;
            if(coupon.DiscountPercentage.HasValue)
            {
                discountAmount = Math.Min(discountAmount, dto.OriginalPrice * coupon.DiscountPercentage.Value);
                if(discountAmount < 0) discountAmount = 0;
            }

            return Result<DiscountDto>.Success(new DiscountDto
            {
                DiscountAmount = discountAmount,
                IsValid = true,
                Message = ""
            });
        }

        public string CanBeUsedByAccount(Coupon coupon, int usageCountByThisAccount, int totalUsageCount)
        {
            if (!coupon.IsActive)
            {
                return "Coupon is not active";
            }
            if (coupon.IsExpired())
            {
                return "Coupon is expired";
            }
            if(usageCountByThisAccount >= coupon.MaxUsagesPerAccount)
            {
                return "This user cannot use this coupon anymore";
            }
            if(totalUsageCount >= coupon.MaxUsages)
            {
                return "This coupon cannot be used anymore";
            }
            return string.Empty;
        }
    }
}

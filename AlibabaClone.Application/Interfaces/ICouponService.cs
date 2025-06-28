using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface ICouponService
    {
        Task<Result<DiscountDto>> ValidateCouponAsync(long accountId, CouponValidationRequestDto dto);
    }
}

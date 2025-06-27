using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AlibabaClone.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class CouponController : ControllerBase
    {
        private readonly IUserContext _userContext;
        private readonly ICouponService _couponService;
        public CouponController(IUserContext userContext, ICouponService couponService)
        {
            _userContext = userContext;
            _couponService = couponService;
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateCoupon(CouponValidationRequestDto dto)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0) return Unauthorized();
            var result = await _couponService.ValidateCouponAsync(accountId, dto);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }
    }
}

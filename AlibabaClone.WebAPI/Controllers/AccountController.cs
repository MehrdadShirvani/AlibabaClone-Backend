using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserContext _userContext;
        private readonly IAccountService _accountService;

        public AccountController(IUserContext userContext, IAccountService accountService)
        {
            _userContext = userContext;
            this._accountService = accountService;
        }

        [Authorize(Roles = "User")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            long userId = _userContext.GetUserId();
            var result = await _accountService.GetProfileAsync(userId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return result.Status switch
            {
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }
    }
}

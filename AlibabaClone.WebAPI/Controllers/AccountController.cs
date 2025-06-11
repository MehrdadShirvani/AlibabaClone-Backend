using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
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

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            long userId = _userContext.GetUserId();
            if(userId <= 0) return Unauthorized();
            var result = await _accountService.GetProfileAsync(userId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return result.Status switch
            {
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }

        [HttpGet("my-travels")]
        public async Task<IActionResult> GetMyTravels()
        {
            long userId = _userContext.GetUserId();
            if (userId <= 0) return Unauthorized();

            var result = await _accountService.GetTravels(userId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return result.Status switch
            {
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }

        [HttpGet("my-travels/{ticketOrderId}")]
        public async Task<IActionResult> GetTravelOrderDetails(long ticketOrderId)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0) return Unauthorized();

            var result = await _accountService.GetTicketOrderTravelersDetails(accountId, ticketOrderId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return result.Status switch
            {
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }

        [HttpGet("my-transactions")]
        public async Task<IActionResult> GetMyTransactions()
        {
            long userId = _userContext.GetUserId();
            if (userId <= 0) return Unauthorized();

            var result = await _accountService.GetTransactions(userId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return result.Status switch
            {
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }


        [HttpPut("email")]
        public async Task<IActionResult> EditEmail([FromBody] EditEmailDto dto)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0) return Unauthorized();

            await _accountService.UpdateEmailAsync(accountId, dto.NewEmail);
            return NoContent();
        }

        [HttpPut("password")]
        public async Task<IActionResult> EditPassword([FromBody] EditPasswordDto dto)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0) return Unauthorized();

            await _accountService.UpdatePasswordAsync(accountId, dto.OldPassword ,dto.NewPassword);
            return NoContent();
        }

        [HttpPost("person")]
        public async Task<IActionResult> UpsertPerson([FromBody] UpsertPersonDto dto)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0) return Unauthorized();

            var result = await _accountService.UpsertPersonAsync(accountId, dto);
            return result.Status switch
            {
                ResultStatus.Success => NoContent(),
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }
    }
}

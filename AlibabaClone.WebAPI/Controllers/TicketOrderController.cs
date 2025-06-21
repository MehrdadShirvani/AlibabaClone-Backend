using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketOrderController : ControllerBase
    {
        private readonly IUserContext _userContext;

        private readonly ITransportationService _transportationService;
        private readonly ITicketOrderService _ticketOrderService;
        public TicketOrderController(IUserContext userContext, ITransportationService transportationService, ITicketOrderService ticketOrderService)
        {
            _userContext = userContext;
            _transportationService = transportationService;
            _ticketOrderService = ticketOrderService;
        }


        [HttpPost("create")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateTicketOrder(CreateTicketOrderDto dto)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0) return Unauthorized();
            var result = await _ticketOrderService.CreateTicketOrderAsync(accountId, dto);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result),
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };

        }
    }
}

using AlibabaClone.Application.Interfaces;
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

    }
}

using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationController : ControllerBase
    {
        private readonly ITransportationService _transportationService;

        public TransportationController(ITransportationService transportationService)
        {
            _transportationService = transportationService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchTransportations([FromBody] TransportationSearchRequestDto searchRequest)
        {
            if (searchRequest == null)
            {
                return BadRequest("Invalid search request.");
            }

            var result = await _transportationService.SearchTransportationsAsync(searchRequest);

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

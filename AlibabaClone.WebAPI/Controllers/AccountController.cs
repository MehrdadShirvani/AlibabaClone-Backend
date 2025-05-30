using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok("Hi there, hello");
        }
    }
}

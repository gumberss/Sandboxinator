using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoraController : ControllerBase
    {
        [HttpGet("User")]
        public async Task<IActionResult> Get()
        {
            return Ok(User.Identity?.Name);
        }

        [HttpPost("User")]
        [Authorize]
        public async Task<IActionResult> Post()
        {
            return Ok(User.Identity?.Name);
        }
    }
}

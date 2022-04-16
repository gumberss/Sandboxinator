using ApiAuth.Models;
using ApiAuth.Repositories;
using Auth_POC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth_POC.Controllers
{
    [ApiController]
    [Route("V1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthAsync([FromBody] User model)
        {
            var user = userRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "User not found" });

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user with { Password = "" },
                token = token
            };

        }
    }
}
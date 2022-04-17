using ApiAuth.Models;
using ApiAuth.Repositories;
using Auth_POC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPost]
        [Route("login-refresh")]
        public async Task<ActionResult<dynamic>> AuthRefreshAsync([FromBody] User model)
        {
            var user = userRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "User not found" });

            var token = TokenService.GenerateToken(user);
            var refreshToken = TokenService.GenerateRefreshToken();
            TokenService.SaveRefreshToken(user.Username, refreshToken);
            return new
            {
                user = user with { Password = "" },
                token = token,
                refreshToken = refreshToken
            };
        }


        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<dynamic>> RefreshAsync(string token, string refreshToken)
        {
            //should wait if token is already expired?
            var principal = TokenService.GetPrincipalFromExpiredToken(token);

            var username = principal.Identity.Name;
            var SaveRefreshToken = TokenService.GetRefreshToken(username);
            if (SaveRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");
            var newJwtToken = TokenService.GenerateToken(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.DeleteRefreshToken(username, refreshToken);
            TokenService.SaveRefreshToken(username, newRefreshToken);
            return new
            {
                token = token,
                refreshToken = refreshToken
            };
        }
    }
}
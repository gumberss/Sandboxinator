using IdentityApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public TestController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet("User")]
        public async Task<IActionResult> Get([FromQuery] string username, string password)
        {
            //var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            var user = await _userManager.FindByNameAsync(username);

            if (user is not null)
            {
                var validPassword = await _userManager.CheckPasswordAsync(user, password);
                if (validPassword)
                {
                    var token = TokenService.GenerateToken(user);
                    return Ok(token);
                }
            }

            return Ok(false);
        }

        [HttpPost("User")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var identityUser = new IdentityUser
            {
                Email = user.Email,
                UserName = user.Name
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
                return Ok(identityUser);

            return BadRequest(result.Errors);
        }
    }

    public class User
    {
        public String Name { get; set; }

        public String Password { get; set; }

        public String Email { get; set; }
    }
}

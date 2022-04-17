using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_POC.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anyone";


    [HttpGet("authenticated")]
    [Authorize]
    public string Auth() => $"Auth - {User.Identity.Name}";

    [HttpGet("authenticated/both")]
    [Authorize(Roles = "Manager,Jarbas")]
    public string AuthRole() => $"Auth Role- {User.Identity.Name}";


    [HttpGet("authenticated/manager")]
    [Authorize(Roles = "Manager")]
    public string AuthManager() => $"Auth Manager- {User.Identity.Name}";

    [HttpGet("authenticated/jarbas")]
    [Authorize("JarbasPolicy")]
    public string Jarbas() => $"Jarbas Policy - {User.Identity.Name}";
}

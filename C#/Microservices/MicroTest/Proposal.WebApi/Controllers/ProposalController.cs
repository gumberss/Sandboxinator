using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProposalValidator.Domain.DTOs;

namespace Proposal.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProposalController : ControllerBase
    {   
        private readonly ILogger<ProposalController> _logger;

        public ProposalController(ILogger<ProposalController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            return "Hello!";
        }

        [HttpPost]
        public void Post([FromBody] ProposalDTO proposal)
        {
            Console.WriteLine(JsonConvert.SerializeObject(proposal));
        }
    }
}

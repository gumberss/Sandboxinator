using System;
using System.Linq;
using System.Threading.Tasks;
using Attendance.Proposals.Data.Contexts;
using Attendance.Proposals.Domain.DTOs;
using Attendance.Proposals.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Proposal.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProposalController : ControllerBase
    {
        private readonly ILogger<ProposalController> _logger;
        private readonly ProposalContext _context;
        private readonly IProposalRepository _proposalRepository;

        public ProposalController(ILogger<ProposalController> logger, IProposalRepository proposalRepository, ProposalContext context)
        {
            _logger = logger;

            _context = context;

            _proposalRepository = proposalRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (_context)
            {
                var data = _proposalRepository.GetAll().ToList();

                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProposalDTO proposal)
        {
            using (_context)
            {
                _proposalRepository.Add(new Attendance.Proposals.Domain.DomainModels.Proposal(Guid.NewGuid(), 100, 5));

                await _context.SaveChangesAsync();

                return Ok();
            }
        }
    }
}

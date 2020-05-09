using Bank.Proposals.Application.Interfaces;
using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Handler
{
    public class ProposalEventsHandler
    {
        private readonly IProposalValidatorAppService _proposalValidator;

        public ProposalEventsHandler(IProposalValidatorAppService proposalValidator)
        {
            _proposalValidator = proposalValidator;
        }

        public void Handle(Proposal proposal)
        {
            var validProposals = _proposalValidator.Validate(proposal);

            //publish message
        }
    }
}

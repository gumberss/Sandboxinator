using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Application.Interfaces
{
    public interface IProposalValidatorAppService
    {
        Proposal Validate(Proposal proposal);
    }
}

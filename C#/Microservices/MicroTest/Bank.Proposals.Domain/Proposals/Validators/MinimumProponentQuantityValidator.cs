using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Domain.Proposals.Validators
{
    public class MinimumProponentQuantityValidator : BaseValidator
    {
        protected override bool ValitationWrapper(Proposal proposal)
        {
            return proposal.Proponents.Count >= 2;
        }
    }
}

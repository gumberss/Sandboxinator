using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Domain.Proposals.Validators
{
    public class WarrantyQuantityValidator : BaseValidator
    {
        protected override bool ValitationWrapper(Proposal proposal)
        {
            return proposal.Warranties.Count >= 1;
        }
    }
}

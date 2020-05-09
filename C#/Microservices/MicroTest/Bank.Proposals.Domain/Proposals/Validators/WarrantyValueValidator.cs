using Bank.Proposals.Domain.Models;
using System.Linq;

namespace Bank.Proposals.Domain.Proposals.Validators
{
    public class WarrantyValueValidator : BaseValidator
    {
        protected override bool ValitationWrapper(Proposal proposal)
        {
            return proposal.Warranties.Sum(x => x.Value) >= proposal.LoanValue * 2;
        }
    }
}

using System.Linq;
using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Domain.Proposals.Validators
{
    public class WarrantyStateValidator : BaseValidator
    {
        protected override bool ValitationWrapper(Proposal proposal)
        {
            var unableStatesToWarranty = new[] { "SC", "PR", "RS" };

            return proposal.Warranties.All(warranty => !unableStatesToWarranty.Contains(warranty.Province));
        }
    }
}

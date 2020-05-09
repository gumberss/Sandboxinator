using System.Linq;
using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Domain.Proposals.Validators
{
    public class ProponentAgeValidator : BaseValidator
    {
        protected override bool ValitationWrapper(Proposal proposal)
        {
            return proposal.Proponents.All(x => x.Age >= 18);
        }
    }
}

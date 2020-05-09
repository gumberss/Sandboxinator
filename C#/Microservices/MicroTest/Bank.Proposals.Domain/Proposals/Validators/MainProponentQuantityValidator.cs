using System.Linq;
using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Domain.Proposals.Validators
{
    public class MainProponentQuantityValidator : BaseValidator
    {
        protected override bool ValitationWrapper(Proposal proposal)
        {
            return proposal.Proponents.Count(x => x.IsMain) == 1;
        }
    }
}

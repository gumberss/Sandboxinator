using Bank.Proposals.Application.Interfaces;
using Bank.Proposals.Domain.Models;
using Bank.Proposals.Domain.Proposals.Validators;

namespace Bank.Proposals.Application.Proposals
{
    public class ProposalValidatorAppService : IProposalValidatorAppService
    {
        public Proposal Validate(Proposal proposal)
        {
            BaseValidator validatorChain = new LoanValueValidator();

            validatorChain
                .SetNext(new LoanMonthlyInStallmentsValidator())
                .SetNext(new MinimumProponentQuantityValidator())
                .SetNext(new MainProponentQuantityValidator())
                .SetNext(new ProponentAgeValidator())
                .SetNext(new WarrantyQuantityValidator())
                .SetNext(new WarrantyValueValidator())
                .SetNext(new WarrantyStateValidator())
                .SetNext(new ProponentIncomeValidator());

            validatorChain.Validate(proposal);

            return proposal.AsInvalid();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using ProposalValidator.Domain.Interfaces;
using ProposalValidator.Domain.Proposals.Validators;

namespace ProposalValidator.Domain.Proposals
{
    public class ValidatorWrapper : IValidatorWrapper
    {
        List<BaseValidator> _validators => new List<BaseValidator>
        {
            new LoanMonthlyInStallmentsValidator(),
            new MinimumProponentQuantityValidator(),
            new MainProponentQuantityValidator(),
            new ProponentAgeValidator(),
            new WarrantyQuantityValidator(),
            new WarrantyValueValidator(),
            new WarrantyStateValidator(),
            new ProponentIncomeValidator()
        };

        public IEnumerator<BaseValidator> GetEnumerator()
        {
            return _validators.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _validators.GetEnumerator();
        }
    }
}

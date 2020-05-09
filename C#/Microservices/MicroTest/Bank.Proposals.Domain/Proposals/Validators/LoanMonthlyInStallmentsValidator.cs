
using Bank.Proposals.Domain.Models;

namespace Bank.Proposals.Domain.Proposals.Validators
{
    public class LoanMonthlyInStallmentsValidator : BaseValidator
    {
        protected override bool ValitationWrapper(Proposal proposal)
        {
            var twoYears = 12 * 2;
            var fifteenYears = 12 * 15;

            return proposal.NumberOfMonthlyInstallments >= twoYears && proposal.NumberOfMonthlyInstallments <= fifteenYears;
        }
    }
}

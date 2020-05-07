using System;
using System.Collections.Generic;
using System.Text;
using ProposalValidator.Domain.Proposals.Validators;

namespace ProposalValidator.Domain.Interfaces
{
    public interface IValidatorWrapper : IEnumerable<BaseValidator>
    {
    }
}

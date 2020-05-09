using System;
using System.Collections.Generic;
using System.Text;
using Bank.Proposals.Domain.Proposals.Validators;

namespace Bank.Proposals.Domain.Interfaces
{
    public interface IValidatorWrapper : IEnumerable<BaseValidator>
    {
    }
}

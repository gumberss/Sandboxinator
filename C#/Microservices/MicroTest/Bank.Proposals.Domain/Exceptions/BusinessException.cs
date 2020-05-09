using System;

namespace Bank.Proposals.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(String message) : base(message) { }
    }
}

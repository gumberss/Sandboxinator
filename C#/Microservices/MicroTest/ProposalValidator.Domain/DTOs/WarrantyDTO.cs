using System;

namespace ProposalValidator.Domain.DTOs
{
    public class WarrantyDTO
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public String Province { get; set; }
    }
}

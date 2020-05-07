using System;
using System.Collections.Generic;

namespace ProposalValidator.Domain.DTOs
{
    public class ProposalDTO
    {
        public Guid Id { get; set; }

        public decimal LoanValue { get; set; }

        public int NumberOfMonthlyInstallments { get; set; }

        public List<ProponentDTO> Proponents { get; set; }

        public List<WarrantyDTO> Warranties { get; set; }
    }
}

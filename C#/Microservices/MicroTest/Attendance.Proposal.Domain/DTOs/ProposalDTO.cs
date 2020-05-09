using System;
using System.Collections.Generic;

namespace Attendance.Proposals.Domain.DTOs
{
    public class ProposalDTO
    {
        public Guid Id { get; set; }

        public decimal LoanValue { get; set; }

        public int NumberOfMonthlyInstallments { get; set; }

        public List<Guid> Proponents { get; set; }

        public List<Guid> Warranties { get; set; }
    }
}

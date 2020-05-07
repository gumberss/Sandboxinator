using System;

namespace ProposalValidator.Domain.DTOs
{
    public class ProponentDTO
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public int Age { get; set; }

        public decimal MonthlyIncome { get; set; }

        public bool IsMain { get; set; }
    }
}

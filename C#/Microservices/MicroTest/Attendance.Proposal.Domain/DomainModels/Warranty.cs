using System;

namespace Attendance.Proposals.Domain.DomainModels
{
    public class Warranty
    {
        public Warranty() { }

        public Warranty(Guid id, decimal value, String province)
        {
            Id = id;
            Value = value;
            Province = province;
        }

        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public String Province { get; set; }

        public Warranty Update(decimal value, String province)
        {
            Value = value;
            Province = province;

            return this;
        }
    }
}

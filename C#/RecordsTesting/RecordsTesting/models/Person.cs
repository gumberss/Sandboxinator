using RecordsTesting.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTesting.models
{
    public record Person : NamedRecord, INamed
    {
        public int Age { get; set; }
        public String Cpf { get; set; }
    }
}

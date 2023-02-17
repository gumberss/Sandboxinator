using RecordsTesting.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTesting.models
{
    public record Machine : NamedRecord, INamed
    {
        public String?  Mark { get; set; }
    }
}

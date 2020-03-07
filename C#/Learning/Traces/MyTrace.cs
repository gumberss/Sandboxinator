using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Learning.Traces
{
    public class MyTrace
    {
        public void Process()
        {
            Trace.WriteLine("Test1");
            Trace.WriteLine("Test2");
            Trace.WriteLine("Test3");
            Trace.WriteLine("Test4");
            Trace.WriteLine("Test5");
        }
    }
}

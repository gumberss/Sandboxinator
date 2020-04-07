using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace LearningFramework.PerformanceCounters
{
    public class MyPerformanceCounter
    {
        public void Process()
        {
            PerformanceCounter counter = new PerformanceCounter("Processor", "% Processor Time", "_Total", readOnly: true);

            for (int i = 0; i < 10; i++)
            {
                //var ii = counter.Increment(); readonly is not be able to increment
                var ns = counter.NextSample();
                var nv = counter.NextValue();

                Console.WriteLine($"NextSample: {ns}, NextValue: {nv }");
            }

        }
    }
}

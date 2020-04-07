using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProcess = new PerformanceCounters.MyPerformanceCounter();

            myProcess.Process();
        }
    }
}

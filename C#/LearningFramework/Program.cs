using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningFramework.Securities;

namespace LearningFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProcess = new ADPrincipal();

            myProcess.Process();
        }
    }
}

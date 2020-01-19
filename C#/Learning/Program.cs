using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            
            var list = Enumerable.Range(0, 10000);

            // Milliseconds 111453
            Slow(list);
            // Milliseconds 11856
            Fast(list);
            // Milliseconds 9232
            //to test you may use 
            //ThreadPool.QueueUserWorkItem(new WaitCallback((a) => Console.WriteLine(mywatch.ElapsedMilliseconds)));
            //after process Faster method
            Faster(list);

        }

        public static void Process(int message)
        {
            Thread.Sleep(10);
            Console.Write(" " + message);
        }

        public static void Faster(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((a) => Process(item)));
            }
        }

        public static void Fast(IEnumerable<int> list)
        {
            Parallel.ForEach(list, item => Process(item));
        }

        public static void Slow(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                Process(item);
            }
        }
    }
}

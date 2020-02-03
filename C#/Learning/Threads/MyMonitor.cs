using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Learning.Threads
{
    public class MyMonitor
    {
        public List<int> Integers { get; set; }

        public MyMonitor()
        {
            Integers = new List<int>();
        }

        public void Process()
        {
            Stopwatch s = new Stopwatch();

            Thread a = new Thread(new ThreadStart(AddIntegers));
            Thread b = new Thread(new ThreadStart(AddIntegers));

            s.Start();

            a.Start();
                b.Start();

            while(a.ThreadState != System.Threading.ThreadState.Stopped && b.ThreadState != System.Threading.ThreadState.Stopped)
            {

            }

                s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);
        }

        public void AddIntegers()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Monitor.Enter(Integers);
                Integers.Add(new Random().Next(0, 10000000));
                Monitor.Exit(Integers);
            }
        }
    }
}

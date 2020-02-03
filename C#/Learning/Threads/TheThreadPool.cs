using System;
using System.Diagnostics;
using System.Threading;

namespace Learning
{
    static class TheThreadPool
    {
        public static void Process()
        {
            Stopwatch mywatch = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");

            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedMilliseconds.ToString());
            mywatch.Reset();


            Console.WriteLine("Thread Execution");

            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedMilliseconds.ToString());
            Console.WriteLine("Time consumed by ProcessWithThreadMethod2  is : " + (double)mywatch.ElapsedTicks / Stopwatch.Frequency);
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 1000; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((a) => Process("p")));
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 1000; i++)
            {
                Thread obj = new Thread(() => Process("t"));
                obj.Start();
            }
        }

        static void Process(String v)
        {
            Thread.Sleep(5);
            Console.Write(v);
        }
    }
}

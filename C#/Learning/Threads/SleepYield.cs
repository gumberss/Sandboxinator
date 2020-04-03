using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learning.Threads
{
    public class SleepYield
    {

        public void Process()
        {
            //"Causes the calling thread to yield execution to another thread that is ready to run on the current processor."
            //Releases the current thread's time slice only if another thread is ready on the same processor. 
            //If there are waiting threads of any priority on the same processor, the time slice is yielded and
            //and the operating system reschedules the current thread according to its priority
            Thread.Yield();

            //If there's any other thread from any process ready to run and has a equal or higher priority then Sleep(0) will yield the processor and let it run
            Thread.Sleep(0);

            //When you pass any non-zero integer argument, the thread unconditionally yields its time slice. 
            //Your application could underutilize its processor resources because the operation system must 
            //switch thread context and reschedule the worker thread even if there are no waiting threads
            Thread.Sleep(1);

            new Thread(ThreadYield).Start();
            new Thread(ThreadYield).Start();

            //Yield().Wait();
        }

        public void ThreadYield()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(5);
                if (Thread.Yield())
                {
                    Console.WriteLine("Changed Thread");
                }
                Console.WriteLine(i);
                
            }
        }

        public async Task Yield()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Console.WriteLine(i);
                await Task.Yield();
            }
        }

    }
}

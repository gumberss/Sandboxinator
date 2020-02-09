using System;
using System.Threading;
using System.Threading.Tasks;

namespace Learning.Threads
{
    public class PlayingWithTasks
    {

        public void Process()
        {
         
            Console.ReadKey();
        }

        public void Threads()
        {
            Thread.CurrentThread.Name = "Main Thread";
            PresentThread(Thread.CurrentThread);

            Thread t1 = new Thread(ExecutionFake);
            t1.Name = "t1";
            t1.Start();
            t1.Join();// Join main thread with this thread, so main thread will wait for this thread

            Thread t2 = new Thread(() => ExecutionFake());
            t2.Name = "t2";
            t2.Start();
            t2.Join();
            

            ParameterizedThreadStart ps = new ParameterizedThreadStart(p => ExecutionFakeParameter(p));

            Thread t3 = new Thread(ps);
            t3.Name = "t3";
            t3.Start("Parameter");
            t3.Join();

            bool stopTicTac = false;

            Thread t4 = new Thread(() =>
            {
                PresentThread(Thread.CurrentThread);

                while (!stopTicTac)
                {
                    Console.WriteLine("Tic");
                    Thread.Sleep(1000);
                    Console.WriteLine("Tac");
                    Thread.Sleep(1000);
                }
            });
            t4.Name = "t4";
            t4.Start();

            Console.WriteLine("press any key to stop the tic tac :D");
            Console.ReadKey();
            stopTicTac = true;
            t4.Join();

            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(state => ExecutionFakeParameter(state), i);
            }
        }

        private void PresentThread(Thread t)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {t.Name}");
            Console.WriteLine($"CurrentCulture: {t.CurrentCulture}");
            Console.WriteLine($"Priority: {t.Priority}");
            Console.WriteLine($"ExecutionContext: {t.ExecutionContext}");
            Console.WriteLine($"IsBackground: {t.IsBackground}");
            Console.WriteLine($"IsThreadPoolThread: {t.IsThreadPoolThread}");
            Console.WriteLine();
        }

        public void ParameterizedThreadStart()
        {
            Thread t1 = new Thread(ExecutionFake);
            Thread t2 = new Thread(() => ExecutionFake());

            t1.Start();
            t2.Start();

            ParameterizedThreadStart ps = new ParameterizedThreadStart(p => ExecutionFakeParameter(p));

            Thread t3 = new Thread(ps);
            t3.Start("Parameter");
        }

        private void ExecutionFake()
        {
            PresentThread(Thread.CurrentThread);

            Console.WriteLine("Executing....");
            Thread.Sleep(1000);
            Console.WriteLine("Ok, that's it");

        }

        private void ExecutionFakeParameter(object o)
        {
            PresentThread(Thread.CurrentThread);

            Console.WriteLine($"Executing {o}....");

            Thread.Sleep(1000);

            Console.WriteLine($"Ok, that's it {o}");

        }

        public void ContinueWith()
        {
            Task
               .Run(() => Console.WriteLine("Hello"))
               .ContinueWith(beforeTask => Console.WriteLine("beautiful"))
               .ContinueWith(beforeTask => Console.WriteLine("and"), TaskContinuationOptions.NotOnCanceled)
               .ContinueWith(beforeTask => Console.WriteLine("unbelivable"), TaskContinuationOptions.NotOnCanceled)
               .ContinueWith(beforeTask => Console.WriteLine("World"), TaskContinuationOptions.NotOnCanceled)
               .ContinueWith(beforeTask => throw new Exception(), TaskContinuationOptions.NotOnCanceled)// After it
               .ContinueWith(beforeTask => Console.WriteLine($"Oh no! an error :( {beforeTask.Exception}"), TaskContinuationOptions.OnlyOnFaulted)//It doesen't work, I don't know why
               .Wait();
        }

        public void Mother()
        {
            var mother = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Mother: Start");

                for (int i = 0; i < 10; i++)
                {
                    Task.Factory.StartNew(
                        state => ChildTask(state)
                      , i
                      , TaskCreationOptions.AttachedToParent
                    );
                }
            });
            mother.Wait();
            Console.WriteLine("Mother: Ending");
        }

        public void ChildTask(object state)
        {
            Console.WriteLine($"Son {state}: Starting");

            Thread.Sleep(1000);

            Console.WriteLine($"Son {state}: Ending");
        }
    }
}

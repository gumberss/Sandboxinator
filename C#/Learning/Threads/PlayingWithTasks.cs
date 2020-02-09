using System;
using System.Threading;
using System.Threading.Tasks;

namespace Learning.Threads
{
    public class PlayingWithTasks
    {

        public void Process()
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
            Console.WriteLine("Executing....");
            Thread.Sleep(1000);
            Console.WriteLine("Ok, that's it");

        }

        private void ExecutionFakeParameter(object o)
        {
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

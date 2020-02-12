using System;
using System.Threading;
using System.Threading.Tasks;

namespace Learning.Threads
{
    public class StopTask
    {
        public void Process()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                        Task.Run(() => Clock(cancellationTokenSource.Token), cancellationTokenSource.Token);

            var countTask = Task.Run(() => Count(cancellationTokenSource.Token), cancellationTokenSource.Token);

            Console.ReadKey();


            cancellationTokenSource.Cancel();

            try
            {
                countTask.Wait();

                Console.WriteLine("The count task was finished with success");
            }
            catch(AggregateException ex)
            {
                Console.WriteLine("The count task was cancelled");
            }
            Console.WriteLine("Stoped");
        }


        private void Clock(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine("Tic");
                Thread.Sleep(500);
                Console.WriteLine("Tac");
                Thread.Sleep(500);
            }
            
        }

        public void Count(CancellationToken token)
        {
            int count = 5;

            while(count >= 0 && !token.IsCancellationRequested)
            {
                Console.WriteLine(count);
                count--;
                Thread.Sleep(500);
            }

            token.ThrowIfCancellationRequested();
        }
    }
}

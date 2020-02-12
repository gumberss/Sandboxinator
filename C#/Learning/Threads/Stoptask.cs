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

            var task1 = Task.Run(() => Clock(cancellationTokenSource.Token), cancellationTokenSource.Token);

            Console.ReadKey();

            cancellationTokenSource.Cancel();
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
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learning.Threads
{
    public class PlayingAsyncTask
    {
        public void Process()
        {
            Stopwatch s = new Stopwatch();

            s.Start();

            Original();

            s.Stop();

            Console.WriteLine($"Time: {s.ElapsedMilliseconds}");

            s.Restart();

            RefatorWithTask();

            s.Stop();

            Console.WriteLine($"Time: {s.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Time: 358
        /// </summary>
        private void RefatorWithTask()
        {
            var tasks = new List<Task>(200);

            foreach (var age in Enumerable.Range(1, 200))
            {
                tasks.Add(UsingTask(age));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private async Task UsingTask(int age)
        {
            Console.WriteLine($"Hello, I'm {age}");

            await Task.Delay(50);
        }

        /// <summary>
        /// Time: 10439
        /// </summary>
        private static void Original()
        {
            foreach (var age in Enumerable.Range(1, 200))
            {
                Console.WriteLine($"Hello, I'm {age}");

                Thread.Sleep(50);
            }
        }
    }
}

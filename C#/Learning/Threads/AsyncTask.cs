using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Threads
{
    public class AsyncTask
    {
        public async Task Process()
        {
            List<Task<int>> tasks = new List<Task<int>>(50);

            for (int i = 0; i < 50; i++)
            {
                tasks.Add(TheProcess(i));
                //Thread.Sleep(100);//Uncomment and execute to see how beautiful tasks are
            }

            var myIntegers = await Task.WhenAll(tasks);

            Console.WriteLine($"Uhuuull!!: {myIntegers.Sum()}");
        }

        public async Task<int> TheProcess(int i)
        {
            Console.WriteLine($"Starting: {i}");
            await Task.Delay(1000);
            Console.WriteLine($"Ending: {i}");
            return ++i;
        }

    }
}

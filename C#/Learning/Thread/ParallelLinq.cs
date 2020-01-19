using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Learning
{
    class ParallelLinq
    {
        void Process()
        {
            Stopwatch s = new Stopwatch();

            var list = Enumerable.Range(0, 10).AsParallel();

            s.Start();

            var result =
                from n in list
                where BuscarNumeroPar(n)
                select n;

            Parallel.ForEach(result, i => Console.Write(i + " "));

            s.Stop();
            Console.WriteLine();
            Console.WriteLine(s.ElapsedMilliseconds);
        }

        private static bool BuscarNumeroPar(int n)
        {
            Thread.Sleep(1000);

            return n % 2 == 0;
        }
    }
}


using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Learning
{
    public class ParallelLinq
    {
        public void Process()
        {
            var list = Enumerable.Range(0, 10);

            var result =
                (from n in list.AsParallel()
                orderby n
                where BuscarNumeroPar(n)
                select n).Take(2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        private static void FirstParallelLinq()
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
            Thread.Sleep((11 - n) * 100);

            return n % 2 == 0;
        }
    }
}


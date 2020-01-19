
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Learning
{
    class ParallelFor
    {
        public void Process()
        {
            Stopwatch s = new Stopwatch();

            s.Start();
            Parallel.Invoke(() => ImprimirZero(), () => ImprimitUm(), () => ImprimirPonto());
            s.Stop();
            Console.WriteLine();
            Console.WriteLine(s.ElapsedMilliseconds);

            Console.WriteLine();

            s.Restart();
            ImprimirZero();
            ImprimitUm();
            ImprimirPonto();
            s.Stop();
            Console.WriteLine();
            Console.WriteLine(s.ElapsedMilliseconds);
        }

        private static void ImprimirPonto()
        {
            var result = Parallel.For(0, 300, (i, state) =>
            {
                Console.Write(".");
                ExecutarTarefaDemorada();

                if (i == 99)
                    state.Break();
            });

            var range = Enumerable.Range(0, 300);

            Parallel.ForEach(range, i =>
            {
                Console.Write(".");
                ExecutarTarefaDemorada();
            });
        }

        private static void ImprimitUm()
        {
            Parallel.For(0, 300, i =>
            {
                Console.Write("1");
                ExecutarTarefaDemorada();
            });

            var range = Enumerable.Range(0, 300);

            Parallel.ForEach(range, i =>
            {
                Console.Write("1");
                ExecutarTarefaDemorada();
            });
        }

        private static void ImprimirZero()
        {
            Parallel.For(0, 300, i =>
            {
                Console.Write("0");
                ExecutarTarefaDemorada();
            });

            var range = Enumerable.Range(0, 300);

            Parallel.ForEach(range, i =>
            {
                Console.Write("0");
                ExecutarTarefaDemorada();
            });

        }

        private static void ExecutarTarefaDemorada()
        {
            Thread.Sleep(10);
        }
    }
}

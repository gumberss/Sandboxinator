using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Learning
{
    class BrakingParallelFor
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

            Console.WriteLine();
            Console.WriteLine("Completou?" + result.IsCompleted + " parou no " + result.LowestBreakIteration);
        }

        private static void ImprimitUm()
        {
            var result = Parallel.For(0, 300, i =>
            {
                Console.Write("1");
                ExecutarTarefaDemorada();
            });
            Console.WriteLine();
            Console.WriteLine("Completou?" + result.IsCompleted + " parou no " + result.LowestBreakIteration);

        }

        private static void ImprimirZero()
        {
            Parallel.For(0, 300, i =>
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

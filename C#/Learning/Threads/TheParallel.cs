using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Learning
{
    public class TheParallel
    {
        void Process()
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
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                System.Console.Write(".");
            }
        }

        private static void ImprimitUm()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                System.Console.Write("1");
            }
        }

        private static void ImprimirZero()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                System.Console.Write("0");
            }
        }

        private static void ExecutarTarefaDemorada()
        {
            Thread.Sleep(10);
        }
    }
}



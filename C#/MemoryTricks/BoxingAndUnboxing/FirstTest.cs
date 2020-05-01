
namespace MemoryTricks.BoxingAndUnboxing
{
    public class FirstTest
    {
        private static int ITERATIONS = 1_000_000_000;

        public static void WithBox()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                DoWork(i);
            }

            void DoWork(object i)
            {
                // do nothing
            }
        }


        public static void WithoutBox()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                DoWork(i);
            }

            void DoWork(int i)
            {
                //do nothing
            }
        }
    }
}

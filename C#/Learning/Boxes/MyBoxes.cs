using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Learning.Boxes
{
    public class MyBoxes
    {
        public void Process()
        {
            var summary = BenchmarkRunner.Run<TestBenchmark>();
            return;

            var a = 123;

            object b = a;

            int c = (int)b;
            //int d1 = (short)b; //You should use Convert.ToInt16 as below
            int d = Convert.ToInt16(b);

            Console.WriteLine(c);
            Console.WriteLine(d);
        }

        public class TestBenchmark
        {
            private const int N = 10000;
            private readonly byte[] data;

            [Benchmark]
            public void Box()
            {
                var a = 123;

                object b = a;

                int c = (int)b;
            }

            [Benchmark]
            public void NoBox()
            {
                int a = 123;

                int b = a;

                int c = b;
            }
        }
    }
}

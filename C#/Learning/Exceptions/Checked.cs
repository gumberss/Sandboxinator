using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Learning.Exceptions
{
    public class Checked
    {
        public void Process()
        {
            Stopwatch s = new Stopwatch();

            s.Start();

            //for (int i = 0; i < 500_000_000; i++)
            //{
            //    Check(i);
            //}
            //s.Stop();
            //Console.WriteLine(s.ElapsedMilliseconds);
            //s.Restart();
            //for (int i = 0; i < 500_000_000; i++)
            //{
            //    Uncheck(i);
            //}
            //s.Stop();
            //Console.WriteLine(s.ElapsedMilliseconds);

            var max = int.MaxValue;

            var returnValue = Check(max);
            Console.WriteLine(returnValue);

            var returnValue2 = Uncheck(max);
            Console.WriteLine(returnValue2);
        }

        public int Check(int number)
        {
            try
            {
                // It won't ignore an arithmetic overflow exception and it will throw an exception if the number is greater then int.MaxValue
                // The checked statements force C# to raise exception whenever underflow or stack overflow exception occurs due to integral type arithmetic or conversion issues.
                checked
                {
                    return number + 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Uncheck(int number)
        {
            try
            {
                // You don't need it here, because it is the default behavior.
                // You can use it inside a checked scope to make part of the checked scope unchecked
                // It will ignore an arithmetic overflow exception and it can return an incorrect data
                // "The unchecked statement ignores the stack overflow exception and executes the program so, the output can be incorrect"
                unchecked
                {
                    return number + 1;
                }
                
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}

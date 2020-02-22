using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Boxes
{
    public class MyBoxes
    {

        public void Process()
        {
            var a = 123;

            object b = a;

            int c = (int)b;
            //int d1 = (short)b; //You should use Convert.ToInt16 as below
            int d = Convert.ToInt16(b);

            Console.WriteLine(c);
            Console.WriteLine(d);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Enums
{
    public class MyEnum
    {
        public void Process()
        {
            var a = Test.None;

            var b = Test.b;

            var bc = Test.b | Test.c;
            
            var lala = Test.b | Test.None;

            var test = b == lala;
        }
    }

    [Flags]
    public enum Test
    {
        None = 0,
        b = 1,
        c = 2,
        d = 4,
        e = 8
    }
}

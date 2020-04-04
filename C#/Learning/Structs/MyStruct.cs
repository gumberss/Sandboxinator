using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Structs
{
    public struct MyStruct
    {
        public void Process()
        {
            var struc = new TheStruct(1,2,3);
            var struc2 = new TheStruct();
         }
    }

    public struct TheStruct
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public double K;

        public TheStruct(double x, double y, double z) 
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.K = 2;
        }

        public TheStruct(double x) : this()
        {
            this.X = x;
        }
    }
}

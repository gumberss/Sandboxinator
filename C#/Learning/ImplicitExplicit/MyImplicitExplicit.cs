using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.ImplicitExplicit
{
    public class MyImplicitExplicit
    {

    }

    public class Point2d
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2d()
        {

        }

        public Point2d(double x, double y) : this()
        {
            X = x;
            Y = y;
        }
    }

    public class Point3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3d()
        {

        }

        public Point3d(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static explicit operator Point2d(Point3d value)
        {
            return new Point2d(value.X, value.Y);
        }

        public static implicit operator Point3d(Point2d value)
        {
            return new Point3d(value.X, value.Y, 0);
        }
    }

}

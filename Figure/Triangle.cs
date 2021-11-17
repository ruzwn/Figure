using System;

namespace Figure
{
    class Triangle : Figure
    {
        public Triangle() : base(3)
        { }

        public Triangle(params double[] coordinates) : base(3, coordinates)
        { }

        public Triangle(params Point[] points) : base(3, points)
        { }

        public Triangle(Triangle other) : base(other)
        { }

        public override void Move(double x = 0, double y = 0)
        {
            base.Move(3, x, y);
        }
    }
}
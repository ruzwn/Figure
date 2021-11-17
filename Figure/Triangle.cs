using System;

namespace Figure
{
    class Triangle : Figure
    {
        public Triangle() : base(3)
        {
        }

        public Triangle(Triangle other) : base(other)
        {
        }

        private bool IsTriangle() // если все точки лежат в одной?
        {
            return Square > double.Epsilon;
        }

        public Triangle(params double[] coordinates)
        {
            Points = new Point[3];
            int coordCount = coordinates.Length;

            for (int i = 0, j = 0; i < 3; i++, j += 2)
            {
                if (j + 1 < coordCount)
                    Points[i] = new Point(coordinates[j], coordinates[j + 1]);
                else if (i < coordCount)
                    Points[i] = new Point(coordinates[i], 0);
                else
                    Points[i] = new Point();
            }

            if (!IsTriangle())
                throw new Exception("Figure is not triangle");
        }

        public Triangle(params Point[] points)
        {
            int pointCnt = points.Length;
            Points = new Point[3];
            for (var i = 0; i < 3; i++)
                Points[i] = (i > pointCnt - 1) ? new Point() : new Point(points[i].X, points[i].Y);

            if (!IsTriangle())
                throw new Exception("Figure is not triangle");
        }

        public override void Move(double x = 0, double y = 0)
        {
            base.Move(3, x, y);
        }
    }
}
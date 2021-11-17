using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    internal abstract class Figure : Point
    {
        protected Point[] Points { get; set; }

        public virtual double Square
        {
            get
            {
                double square = 0;
                int pointCnt = Points.Length;
                for (int i = 0; i < pointCnt - 1; i++)
                    square += Points[i].X * Points[i + 1].Y -
                              Points[i + 1].X * Points[i].Y;
                return square = 0.5 * (Math.Abs(square +
                                                Points[pointCnt - 1].X * Points[0].Y -
                                                Points[0].X * Points[pointCnt - 1].Y));
            }
        }

        protected Figure(int dotCount)
        {
            Points = new Point[dotCount];
            for (var i = 0; i < dotCount; i++)
                Points[i] = new Point();
        }

        protected Figure(int dotCount, params double[] coordinates)
        {
            Points = new Point[dotCount];
            Points[0] = (coordinates.Length <= dotCount - 1) ? new Point() :
                new Point(coordinates[0], coordinates[1]);
            for (int i = 1, j = 2; i < dotCount; i++, j *= 2)
                Points[i] = (j > coordinates.Length - 1) ? new Point() :
                            new Point(coordinates[j], coordinates[j + 1]);
        }

        protected Figure(int dotCount, Point[] points)
        {
            Points = new Point[dotCount];
            for (var i = 0; i < dotCount; i++)
                Points[i] = (i > points.Length - 1) ? new Point() : 
                            new Point(points[i].X, points[i].Y);
        }

        protected Figure(Figure other)
        {
            Points = (Point[])other.Points.Clone();
        }

        public void Move(int dotCount, double x, double y)
        {
            for (var i = 0; i < dotCount; i++)
                Points[i].Move(x, y);
        }

        public static int Compare(Figure obj1, Figure obj2)
        {
            if (Math.Abs(obj1.Square - obj2.Square) < double.Epsilon)
                return 0;
            return obj1.Square > obj2.Square ? 1 : -1;
        }

        private static double GetTriangleSquare(params Point[] points)
        {
            double square = 0;
            int pointCnt = 3;
            for (int i = 0; i < 2; i++)
                square += points[i].X * points[i + 1].Y -
                          points[i + 1].X * points[i].Y;
            return square = 0.5 * (Math.Abs(square +
                                            points[pointCnt - 1].X * points[0].Y -
                                            points[0].X * points[pointCnt - 1].Y));
        }

        private static bool IsIncludePoint(Figure obj, Point point)
        {
            double square = 0;
            int pointCounts = obj.Points.Length;
            for (int i = 0; i < pointCounts; i++)
                square += GetTriangleSquare(point,
                                            obj.Points[i], 
                                            obj.Points[i == pointCounts - 1 ? 0 : i + 1]);
            return Math.Abs(obj.Square - square) < double.Epsilon;
        }
        
        public static bool IsInclude(Figure obj1, Figure obj2) // Is obj1 include obj2?
        {
            if (obj1.Square + double.Epsilon < obj2.Square)
                return false;
            for (int i = 0; i < obj2.Points.Length; i++)
                if (!IsIncludePoint(obj1, obj2.Points[i]))
                    return false;
            return true;
        }

        public static bool IsIntersect(Figure obj1, Figure obj2)
        {
            int includedpoints1 = 0;
            int includedpoints2 = 0;
            for (int i = 0; i < obj2.Points.Length; i++)
                if (IsIncludePoint(obj1, obj2.Points[i]))
                    includedpoints1++;
            for (int i = 0; i < obj1.Points.Length; i++)
                if (IsIncludePoint(obj2, obj2.Points[i]))
                    includedpoints2++;
            if (includedpoints1 == 0 && includedpoints2 == 0)
                return false;
            else if (includedpoints1 == obj2.Points.Length)
                return false;
            else if (includedpoints2 == obj1.Points.Length)
                return false;
            else
                return true;
        }
    }
}
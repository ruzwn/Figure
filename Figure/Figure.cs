using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    internal abstract class Figure : Point
    {
        protected Point[] Points { get; init; }

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

        protected Figure()
        {
        }

        protected Figure(int dotCount)
        {
            Random randX = new Random();
            Random randY = new Random();
            Points = new Point[dotCount];
            
            for (int i = 0; i < dotCount; i++)
                Points[i] = new Point(randX.NextDouble(), randY.NextDouble());
        }

        protected Figure(Figure other)
        {
            Points = (Point[])other.Points.Clone();
        }

        
        protected void Move(int dotCount, double x, double y)
        {
            for (int i = 0; i < dotCount; i++)
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
            {
                if (!IsIncludePoint(obj1, obj2.Points[i]))
                    return false;
            }
            
            return true;
        }

        private static int GetCountIncludedPoints(Figure obj1, Figure obj2)
        {
            int inclPoints = 0;
            
            for (int i = 0; i < obj2.Points.Length; i++)
            {
                if (IsIncludePoint(obj1, obj2.Points[i]))
                    inclPoints++;
            }
            
            return inclPoints;
        }
        
        public static bool IsIntersect(Figure obj1, Figure obj2)
        {
            int inclPoints1 = GetCountIncludedPoints(obj1, obj2);
            int inclPoints2 = GetCountIncludedPoints(obj2, obj1);
            
            if (inclPoints1 == 0 && inclPoints2 == 0)
                return false;
            else if (inclPoints1 == obj2.Points.Length)
                return false;
            else if (inclPoints2 == obj1.Points.Length)
                return false;
            else
                return true;
        }

        public override string ToString()
        {
            string str = string.Empty;

            for (int i = 0; i < Points.Length; ++i)
            {
                str += Points[i].X + "\t" + Points[i].Y;
                if (i + 1 < Points.Length)
                    str += "\n";
            }

            return str;
        }
    }
}
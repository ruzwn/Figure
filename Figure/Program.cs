using System;

namespace Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle temp = new Triangle();
            Console.WriteLine(temp);
            Console.WriteLine(temp.Square);
            Triangle t1 = new Triangle(0, 0, 3, 3, 3, 0);
            Triangle t2 = new Triangle(0, 0, -3, -3, -3, 0);
            Triangle t3 = new Triangle(1, 2);
            Rectangle r1 = new Rectangle(0, 1, 2, 2);
            Console.WriteLine(t1.Square);
            Console.WriteLine(t2.Square);
            Console.WriteLine(t3.Square);
            Console.WriteLine(Figure.IsInclude(t1, t3) ? "Include" : "Not Include");
            Console.WriteLine(Figure.IsInclude(t2, t3) ? "Include" : "Not Include");
            Console.WriteLine(Figure.IsInclude(t1, t2) ? "Include" : "Not Include");
            Console.WriteLine(Figure.IsInclude(t1, t1) ? "Include" : "Not Include");
            Console.WriteLine(Figure.IsIntersect(t1, t2) ? "Intersect" : "Not Intersect");
            Console.WriteLine(Figure.IsInclude(t1,r1) ? "Include" : "Not Include");
            Console.WriteLine(Figure.IsIntersect(t1, r1) ? "Intersect" : "Not Intersect");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
	internal class Point
	{
		public double X { get; private set; }

		public double Y { get; private set; }

		public Point(double x = 0, double y = 0)
		{
			(X, Y) = (x, y);
		}

		public virtual void Move(double x = 0, double y = 0)
		{
			(X, Y) = (X + x, Y + y);
		}
	}
}

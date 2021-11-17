using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Figure
{
	class Rectangle : Figure
	{
		public override double Square
		{
			get
			{
				var x = Math.Max(Points[0].X, Points[1].X) -
				        Math.Min(Points[0].X, Points[1].X);
				var y = Math.Max(Points[0].Y, Points[1].Y) -
				        Math.Min(Points[0].Y, Points[1].Y);
				
				return x * y;
			}
		}

		public Rectangle() : base(4)
		{
		}

		public Rectangle(Rectangle other) : base(other)
		{
		}

		private bool IsRectangle()
		{
			return Square > double.Epsilon;
		}

		private void AddTwoPoints()
		{
			Points[2] = new Point(Points[0].X, Points[1].Y);
			Points[3] = new Point(Points[1].X, Points[0].Y);
		}

		public Rectangle(params double[] coordinates) // have to get 2 points
		{
			Points = new Point[4];
			int coordCount = coordinates.Length;
			
			for (int i = 0, j = 0; i < 2; i++, j += 2)
			{
				if (j + 1 < coordCount)
					Points[i] = new Point(coordinates[j], coordinates[j + 1]);
				else if (i < coordCount)
					Points[i] = new Point(coordinates[i], 0);
				else
					Points[i] = new Point();
			}

			if (!IsRectangle())
				throw new Exception("Figure is not rectangle");

			AddTwoPoints();
		}

		public Rectangle(params Point[] points) // have to get 2 points
		{
			int pointCnt = points.Length;
			Points = new Point[4];
			
			for (var i = 0; i < 2; i++)
				Points[i] = (i > pointCnt - 1) ? new Point() : new Point(points[i].X, points[i].Y);
			
			if (!IsRectangle())
				throw new Exception("Figure is not rectangle");

			AddTwoPoints();
		}

		public override void Move(double x = 0, double y = 0)
		{
			base.Move(4, x, y);
		}
	}
}
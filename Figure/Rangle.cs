using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Figure
{
	class Rectangle : Figure
	{
		public override  double Square
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

		public Rectangle() : base(2)
		{ }

		public Rectangle(params double[] coordinates) // : base(2, coordinates)
		{	
		}

		public Rectangle(params Point[] points) : base(2, points)
		{
			
		}

		public Rectangle(Rectangle other) : base(other)
		{ }

		public Rectangle(Figure other) : base(other)
		{ }

		public override void Move(double x = 0, double y = 0)
		{
			base.Move(2, x, y);
		}
	}
}
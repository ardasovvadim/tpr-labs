using System;
using System.Linq;

namespace ComplexMathLib
{
	public class ComplexMath
	{
		public void Add(double a, double b, double c, double d, out double res1, out double res2)
		{
			res1 = a + c;
			res2 = b + d;
		}
		public void Substract(double a, double b, double c, double d, out double res1, out double res2)
		{
			res1 = a - d;
			res2 = b - c;
		}
		public void Multiply(double a, double b, double c, double d, out double res1, out double res2)
		{
			var array = new[] { a * c, a * d, b * c, b * d };
			res1 = array.Min();
			res2 = array.Max();
		}
		public void Divide(double a, double b, double c, double d, out double res1, out double res2)
		{
			Multiply(a, b, 1 / d, 1 / c, out res1, out res2);
		}
	}
}

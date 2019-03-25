using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNums
{
	class ComplexNum
	{
		private double a,b;
		public double A
		{
			set
			{
				a = value;
			}
			get
			{
				return a;
			}
		}
		public double B
		{
			set
			{
				b = value;
			}
			get
			{
				return b;
			}
		}
	}
	class Actions
	{
		public ComplexNum sum(ComplexNum v1, ComplexNum v2, double ir1, double kexc1, double ir2, double kexc2)
		{
			v1 = new ComplexNum(); v2 = new ComplexNum();
			v1.A = ir1; v1.B = kexc1; v2.A = ir2; v2.B = kexc2;
			ComplexNum ans = new ComplexNum();
			ans.A = v1.A + v2.A;
			ans.B = v1.B + v2.B;
			return ans;
		}
		public ComplexNum subtr(ComplexNum v1, ComplexNum v2, double ir1, double kexc1, double ir2, double kexc2)
		{
			v1 = new ComplexNum(); v2 = new ComplexNum();
			v1.A = ir1; v1.B = kexc1; v2.A = ir2; v2.B = kexc2;
			ComplexNum ans = new ComplexNum();
			ans.A = v1.A - v2.A;
			ans.B = v1.B - v2.B;
			return ans;
		}
		public ComplexNum mult(ComplexNum v1, ComplexNum v2, double ir1, double kexc1, double ir2, double kexc2)
		{
			v1 = new ComplexNum(); v2 = new ComplexNum();
			v1.A = ir1; v1.B = kexc1; v2.A = ir2; v2.B = kexc2;
			ComplexNum ans = new ComplexNum();
			ans.A = v1.A * v2.A - v1.B * v2.B;ans.B = v1.A * v2.B + v2.A * v1.B;
			return ans;
		}
		public ComplexNum div(ComplexNum v1, ComplexNum v2, double ir1, double kexc1, double ir2, double kexc2)
		{
			v1 = new ComplexNum(); v2 = new ComplexNum();
			v1.A = ir1; v1.B = kexc1; v2.A = ir2; v2.B = kexc2;
			ComplexNum ans = new ComplexNum();
			ans.A = (v1.A * v2.A + v1.B * v2.B) / (v2.A * v2.A + v2.B * v2.B);ans.B = (v2.A * v1.B - v1.A * v2.B) / (v2.A * v2.A + v2.B * v2.B);
			return ans;
		}
		public double abs(ComplexNum v1, double ir1, double kexc1)
		{
			v1 = new ComplexNum();v1.A = ir1;v1.B = kexc1;
			return Math.Sqrt(v1.A * v1.A + v1.B * v1.B);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("This program works with complex numbers.Enter the real and imaginary parts of two complex numbers respectively, and then enter the operation sign <+,-,*,/,|(for the numbers' absolute value)>");
			string line = new string('-', 70);Console.WriteLine(); Console.WriteLine(line);
			double Rez1, Imz1, Rez2, Imz2; char sign;
			Rez1 = Convert.ToDouble(Console.ReadLine());
			Imz1 = Convert.ToDouble(Console.ReadLine());
			Rez2 = Convert.ToDouble(Console.ReadLine());
			Imz2 = Convert.ToDouble(Console.ReadLine());
			sign = Convert.ToChar(Console.ReadLine());
			string nsh,ans="";
			ComplexNum a = new ComplexNum(); ComplexNum b = new ComplexNum(); Actions c = new Actions();
			if (sign == '+')
			{
				ComplexNum answer = c.sum(a, b, Rez1, Imz1, Rez2, Imz2);
				ans += answer.A + (nsh = (answer.B >= 0) ? "+" : "") + answer.B + "i";
			}
			else if (sign == '-')
			{
				ComplexNum answer = c.subtr(a, b, Rez1, Imz1, Rez2, Imz2);
				ans += answer.A + (nsh = (answer.B >= 0) ? "+" : "") + answer.B + "i";
			}
			else if (sign == '*')
			{
				ComplexNum answer = c.mult(a, b, Rez1, Imz1, Rez2, Imz2);
				ans += answer.A + (nsh = (answer.B >= 0) ? "+" : "") + answer.B + "i";
			}
			else if (sign == '/')
			{
				ComplexNum answer = c.div(a, b, Rez1, Imz1, Rez2, Imz2);
				ans += answer.A + (nsh = (answer.B >= 0) ? "+" : "") + answer.B + "i";
			}
			else if (sign == '|')
			{
				double absoluteA = c.abs(a, Rez1, Imz1); double absoluteB = c.abs(b, Rez2, Imz2);
				ans += absoluteA + " " + absoluteB;
			}
			Console.WriteLine(ans);
			Console.ReadKey();
		}
	}
}

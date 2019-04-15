using System;
using System.Collections.Generic;
using System.Threading;

namespace RollingDie
{
	class Evs
	{
		public delegate void Deleg();
		public event Deleg TwoFours;
		public event Deleg SumMoreTwenty;
		public int amount = 0;
		public void OnEvents(int n)
		{
			int num,sum=0;
			List<int> DieNumsList = new List<int>();
			Random rnd = new Random();
			for (int i = 1; i <= n; i++)
			{
				num = rnd.Next(1, 7);
				Console.WriteLine(num);
				DieNumsList.Add(num);
				if (i > 1)
				{
					if (DieNumsList[i - 2] == num && num == 4)
					{
						amount++;
						TwoFours();
					}
				}
				if (i < 5)
				{
					sum += num;
				}
				else if (i == 5)
				{
					sum += num;
					if (sum >= 20)
					{
						SumMoreTwenty();
					}
				}
				else
				{
					sum -= DieNumsList[i - 6];
					sum += num;
					if (sum >= 20)
					{
						SumMoreTwenty();
					}
				}
				Thread.Sleep(1000);
			}
		}
	}
	class Program
	{
		public static void TwoFoursPrinter()
		{
			Console.WriteLine("Two fours in a row!!!!!!!");
		}
		public static void SumMoreTwentyPrinter()
		{
			Console.WriteLine("Sum of last 5 tosses' numbers is >=20");
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of tosses");
			int n = Convert.ToInt32(Console.ReadLine());
			Evs evnt = new Evs();
			evnt.TwoFours += TwoFoursPrinter;
			evnt.SumMoreTwenty += SumMoreTwentyPrinter;
			evnt.OnEvents(n);
			Console.WriteLine("The number of 'Two fours in a roll' is:");
			Console.WriteLine(evnt.amount);
			Console.ReadKey();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
	class Actions
	{
		public static int counter = 0;
		private int num;
		public delegate void Act(object source,EventArgs args);
		public event Act SomeEvent;
		public void Printer(object source, EventArgs args)
		{
			Console.WriteLine("New Random Number!!");
		}
		public void NumPrinter(object source, EventArgs args)
		{
			Console.WriteLine($"The number is {this.num}");
		}
		public void Generator(object source, EventArgs args)
		{
			Random rnd = new Random();
			this.num = rnd.Next(1, 11);
		}
		
		public  void OnSomeEvent()
		{
			SomeEvent(this, EventArgs.Empty);
		}
	}
	class Program
	{
        static void Main(string[] args)
        {
			Actions a = new Actions();
			a.SomeEvent += a.Generator;
			a.SomeEvent += a.Printer;
			a.SomeEvent += a.NumPrinter;
			a.OnSomeEvent();
			Console.ReadKey();
        }
    }
}

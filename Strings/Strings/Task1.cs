//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Strings
//{
//	class EventRaiser
//	{
//		public event Action FireAlarm;
//		public void OnFireAlarm(string name)
//		{
//			if (FireAlarm != null)
//			{
//				if (name == "Jack" || name == "Steven" || name == "Mathew")
//				{
//					this.FireAlarm();
//				}
//				else
//					Console.WriteLine($"Welcome to {name}");
//			}
//		}
//	}
//	class Task1
//	{
//		public static void AlarmRiser()
//		{
//			Console.WriteLine("Banned name!!!!!");
//		}
//		static void Main(string[] args)
//		{
//			EventRaiser eventRaiser = new EventRaiser();
//			Console.WriteLine("Write your name!");
//			string name = Console.ReadLine();
//			eventRaiser.FireAlarm += AlarmRiser;
//			eventRaiser.OnFireAlarm(name);
//			Console.ReadKey();
//		}
//	}
//}

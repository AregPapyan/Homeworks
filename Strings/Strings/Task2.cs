//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Strings
//{
//	class Task2
//	{
//		static void Main(string[] args)
//		{
//			Console.WriteLine("Write the string");
//			string name = Console.ReadLine();
//			string[] parts = name.Split(' ');
//			if (parts.Length > 1)
//			{
//				for (int i = 0; i < parts.Length; i++)
//				{
//					Console.Write(parts[i][0].ToString().ToUpper());
//				}
//				Console.WriteLine();
//			}
//			else
//				Console.WriteLine("Too short string!");
//			Console.ReadKey();
//		}
//	}
//}
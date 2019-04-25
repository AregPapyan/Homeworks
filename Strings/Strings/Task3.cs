//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Strings
//{
//	public class Airport
//	{
//		public string Name { get; set; }
//		public string CountryCode { get; set; }
//		public string Size { get; set; }
//	}
//	public class AirportComparer : Comparer<Airport>
//	{
//		private enum Sizes
//		{
//			Small=0,
//			Medium=1,
//			Large=2,
//			Mega=3,
//			SuperMega=4,
//		}
//		public override int Compare(Airport x, Airport y)
//		{
//			return ((int)Enum.Parse(typeof(Sizes), x.Size)).CompareTo((int)Enum.Parse(typeof(Sizes), y.Size));
//		}

//		private static readonly AirportComparer instance = new AirportComparer();
//		public static AirportComparer Instance  { get { return instance; } }
//	}
//	public class Reader
//	{
//		private string fileName;
//		public Reader()
//		{

//		}
//		public Reader(string fileName)
//		{
//			this.fileName = fileName;
//		}
//		public List<Airport> ReadFile(string fileName)
//		{
//			int lineCount = 0;
//			List<Airport> Airports = new List<Airport>();
//			using (StreamReader reader = new StreamReader(fileName))
//			{
//				while (!reader.EndOfStream)
//				{
//					string line = reader.ReadLine();
//					string[] columns = line.Split(' ');
//					Airport Air = new Airport()
//					{
//						Name = columns[0],
//						CountryCode = columns[1],
//						Size = columns[2],
//					};
//					Airports.Add(Air);
//					lineCount++;
//				}
//			}
//			return Airports;
//		}
//	}
//	class Task3
//	{
//		static void Main(string[] args)
//		{
//			Reader reader = new Reader();
//			List<Airport> Airports = reader.ReadFile("Test data for Exercise 3.txt");
//			Airports.Sort(AirportComparer.Instance);
//			foreach (var item in Airports)
//			{
//				Console.Write($"{item.Name}-{item.CountryCode}-{item.Size}");
//				Console.WriteLine();
//			}
//			Console.ReadKey();
//		}
//	}
//}
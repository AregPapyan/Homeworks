using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortAlgo
{
	class CommonOper
	{
		public long mem1, mem2, time;
		public string name = "";
		public void ReDistr(int[] SortedArr, int[] PrimArr, int arrLength)
		{
			for (int p = 0; p < arrLength; p++)
				SortedArr[p] = PrimArr[p];
		}
		public void Printer(long jamanak, long hish)
		{
			Console.Write($"{this.name}\nRunning Time: {jamanak}ms\nMemory Usage: {hish}bytes\n\n");
		}
		public void PrinterInColor(long jamanak,long hish)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write($"{this.name}\n");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.Write($"Running Time: {jamanak}ms\nMemory Usage: {hish}bytes\n\n");
		}
	}
	class Insertion: CommonOper
	{
		public void Namer()
		{
			this.name = "Insertion Sort:";
		}
		public void Sort(int []SortedArr,int arrLength)
		{
			for (int i = 1; i < arrLength; i++)
			{
				int key = SortedArr[i];
				int j = i - 1;
				while (j >= 0 && SortedArr[j] > key)
				{
					SortedArr[j + 1] = SortedArr[j];
					j -= 1;
				}
				SortedArr[j + 1] = key;
			}
		}
		public void Sorting(int[] SortedArr, int arrLength)
		{
			Stopwatch st = Stopwatch.StartNew();
			mem1 = GC.GetTotalMemory(false);
			Sort(SortedArr,arrLength);
			mem2 = GC.GetTotalMemory(false);
			st.Stop();
			time = st.ElapsedMilliseconds;
		}
	}
	class Bubble:CommonOper
	{
		public void Namer()
		{
			this.name = "Bubble Sort:";
		}
		public void Sort(int[] SortedArr, int arrLength)
		{
			for (int i = 0; i < arrLength-1; i++)
			{
				for (int j = 0; j < arrLength - i - 1; j++)
				{
					if (SortedArr[j] > SortedArr[j + 1])
					{
						int temp = SortedArr[j];
						SortedArr[j] = SortedArr[j + 1];
						SortedArr[j + 1] = temp;
					}
				}
			}
		}
		public void Sorting(int[] SortedArr, int arrLength)
		{
			Stopwatch st = Stopwatch.StartNew();
			mem1 = GC.GetTotalMemory(false);
			Sort(SortedArr, arrLength);
			mem2 = GC.GetTotalMemory(false);
			st.Stop();
			time = st.ElapsedMilliseconds;
		}
	}
	class Merge: CommonOper
	{
		public void Namer()
		{
			this.name = "Merge Sort:";
		}
		public void Sort(int[] SortedArr,int l,int m,int r)
		{
			
				int i, j, k, n1 = m - l + 1, n2 = r - m;
				int[] L = new int[n1]; int[] R = new int[n2];
				for (i = 0; i < n1; i++)
					L[i] = SortedArr[l + i];
				for (j = 0; j < n2; j++)
					R[j] = SortedArr[m + 1 + j];
				i = 0; j = 0; k = l;
				while (i < n1 && j < n2)
				{
					if (L[i] <= R[j])
					{
						SortedArr[k] = L[i];
						i++;
					}
					else
					{
						SortedArr[k] = R[j];
						j++;
					}
					k++;
				}
				while (i < n1)
				{
					SortedArr[k] = L[i];
					i++;
					k++;
				}
				while (j < n2)
				{
					SortedArr[k] = R[j];
					j++;
					k++;
				}
		}
		public void mergeSort(int[] SortedArr, int l, int r)
		{
			if (l < r)
			{
				int m = l + (r - l) / 2;
				mergeSort(SortedArr, l, m);
				mergeSort(SortedArr, m + 1, r);

				Sort(SortedArr, l, m, r);
			}
		}
		public void Sorting(int[] SortedArr,int l,int r)
		{
			Stopwatch st = Stopwatch.StartNew();
			mem1 = GC.GetTotalMemory(false);
			mergeSort(SortedArr, l,r);
			mem2 = GC.GetTotalMemory(false);
			st.Stop();
			time = st.ElapsedMilliseconds;
		}
	}
	class Quick:CommonOper
	{
		public void Namer()
		{
			this.name = "Quick Sort:";
		}
		public int partition(int[] SortedArr, int low, int high)
		{
			int pivot = SortedArr[high];
			int i = low - 1;
			for (int j = low; j < high; j++)
			{
				if (SortedArr[j] <= pivot)
				{
					i++;
					int temp = SortedArr[i];
					SortedArr[i] = SortedArr[j];
					SortedArr[j] = temp;
				}
			}
			int temp1 = SortedArr[i + 1];
			SortedArr[i + 1] = pivot;
			SortedArr[high] = temp1;
			return i + 1;
		}
		public void Sort(int[] SortedArr, int low, int high)
		{
			if (low < high)
			{
				int pi = partition(SortedArr, low, high);
				Sort(SortedArr, low, pi - 1);
				Sort(SortedArr, pi + 1, high);
			}
		}
		public void Sorting(int[] SortedArr, int low, int high)
		{
			Stopwatch st = Stopwatch.StartNew();
			mem1 = GC.GetTotalMemory(false);
			Sort(SortedArr, low, high);
			mem2 = GC.GetTotalMemory(false);
			st.Stop();
			time = st.ElapsedMilliseconds;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Insertion ins = new Insertion(); Bubble bub = new Bubble(); Merge mer = new Merge(); Quick qui = new Quick();
			int n;
			long minRuntime=-1;
			string selection;
			Console.WriteLine("Please enter the size of an array you want to sort:");
			n = Convert.ToInt32(Console.ReadLine());
			int[] Numarr = new int[n];
			int[] SortedNumarr = new int[n];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				Numarr[i] = rnd.Next(-2147483648,2147483647);
			Console.Write("Select which algorithm you want to perform:\n1.Insertion Sort\n2.Bubble Sort\n3.Merge Sort\n4.Quick Sort\n5.All\n");			
			selection = Console.ReadLine();
			if (selection.Length == 1)
			{
				if (selection == "1")
				{
					ins.ReDistr(SortedNumarr, Numarr, n);
					ins.Sorting(SortedNumarr, n);
					ins.Namer();
					ins.Printer(ins.time, ins.mem2 - ins.mem1);
				}
				else if (selection == "2")
				{
					bub.ReDistr(SortedNumarr, Numarr, n);
					bub.Sorting(SortedNumarr, n);
					bub.Namer();
					bub.Printer(bub.time, bub.mem2 - bub.mem1);
				}
				else if (selection == "3")
				{
					mer.ReDistr(SortedNumarr, Numarr, n);
					mer.Sorting(SortedNumarr, 0, n - 1);
					mer.Namer();
					mer.Printer(mer.time, mer.mem2 - mer.mem1);
				}
				else if (selection == "4")
				{
					qui.ReDistr(SortedNumarr, Numarr, n);
					qui.Sorting(SortedNumarr, 0, n - 1);
					qui.Namer();
					qui.Printer(qui.time, qui.mem2 - qui.mem1);
				}
				else if (selection == "5")
				{
					int counter = 0;
					long[] times = new long[4];
					long[] memories = new long[4];
					string[] calls = new string[4];
					for (int i = 1; i <= 4; i++)
					{
						if (i.ToString() == "1")
						{
							calls[counter] = "1";
							ins.ReDistr(SortedNumarr, Numarr, n);
							ins.Sorting(SortedNumarr, n);
							times[counter] = ins.time;
							memories[counter] = ins.mem2 - ins.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (ins.time <= minRuntime)
									minRuntime = ins.time;
							}
							else
								minRuntime = ins.time;
						}
						else if (i.ToString() == "2")
						{
							calls[counter] = "2";
							bub.ReDistr(SortedNumarr, Numarr, n);
							bub.Sorting(SortedNumarr, n);
							times[counter] = bub.time;
							memories[counter] = bub.mem2 - bub.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (bub.time <= minRuntime)
									minRuntime = bub.time;
							}
							else
								minRuntime = bub.time;
						}
						else if (i.ToString() == "3")
						{
							calls[counter] = "3";
							mer.ReDistr(SortedNumarr, Numarr, n);
							mer.Sorting(SortedNumarr, 0, n - 1);
							times[counter] = mer.time;
							memories[counter] = mer.mem2 - mer.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (mer.time <= minRuntime)
									minRuntime = mer.time;
							}
							else
								minRuntime = mer.time;
						}
						else if (i.ToString() == "4")
						{
							calls[counter] = "4";
							qui.ReDistr(SortedNumarr, Numarr, n);
							qui.Sorting(SortedNumarr, 0, n - 1);
							times[counter] = qui.time;
							memories[counter] = qui.mem2 - qui.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (qui.time <= minRuntime)
									minRuntime = qui.time;
							}
							else
								minRuntime = qui.time;
						}
					}
					for (int i = 0; i < calls.Length; i++)
					{
						if (calls[i] == "1")
						{
							ins.Namer();
							if (times[i] == minRuntime)
								ins.PrinterInColor(times[i], memories[i]);
							else
								ins.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "2")
						{
							bub.Namer();
							if (times[i] == minRuntime)
								bub.PrinterInColor(times[i], memories[i]);
							else
								bub.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "3")
						{
							mer.Namer();
							if (times[i] == minRuntime)
								mer.PrinterInColor(times[i], memories[i]);
							else
								mer.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "4")
						{
							qui.Namer();
							if (times[i] == minRuntime)
								qui.PrinterInColor(times[i], memories[i]);
							else
								qui.Printer(times[i], memories[i]);
						}
					}
				}
			}
			else if (selection.Length == 3)
			{
				if (selection[1] == '-')
				{
					int interval = Convert.ToInt32(selection[2].ToString()) - Convert.ToInt32(selection[0].ToString()) + 1;
					int counter = 0;
					long[] times = new long[interval];
					long[] memories = new long[interval];
					string[] calls = new string[interval];
					for (int i = Convert.ToInt32(selection[0].ToString()); i <= Convert.ToInt32(selection[2].ToString()); i++)
					{
						if (i.ToString() == "1")
						{
							calls[counter] = "1";
							ins.ReDistr(SortedNumarr, Numarr, n);
							ins.Sorting(SortedNumarr, n);
							times[counter] = ins.time;
							memories[counter] = ins.mem2 - ins.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (ins.time <= minRuntime)
									minRuntime = ins.time;
							}
							else
								minRuntime = ins.time;
						}
						else if (i.ToString() == "2")
						{
							calls[counter] = "2";
							bub.ReDistr(SortedNumarr, Numarr, n);
							bub.Sorting(SortedNumarr, n);
							times[counter] = bub.time;
							memories[counter] = bub.mem2 - bub.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (bub.time <= minRuntime)
									minRuntime = bub.time;
							}
							else
								minRuntime = bub.time;
						}
						else if (i.ToString() == "3")
						{
							calls[counter] = "3";
							mer.ReDistr(SortedNumarr, Numarr, n);
							mer.Sorting(SortedNumarr, 0, n - 1);
							times[counter] = mer.time;
							memories[counter] = mer.mem2 - mer.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (mer.time <= minRuntime)
									minRuntime = mer.time;
							}
							else
								minRuntime = mer.time;
						}
						else if (i.ToString() == "4")
						{
							calls[counter] = "4";
							qui.ReDistr(SortedNumarr, Numarr, n);
							qui.Sorting(SortedNumarr, 0, n - 1);
							times[counter] = qui.time;
							memories[counter] = qui.mem2 - qui.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (qui.time <= minRuntime)
									minRuntime = qui.time;
							}
							else
								minRuntime = qui.time;
						}
					}
					for (int i = 0; i < calls.Length; i++)
					{
						if (calls[i] == "1")
						{
							ins.Namer();
							if (times[i] == minRuntime)
								ins.PrinterInColor(times[i], memories[i]);
							else
								ins.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "2")
						{
							bub.Namer();
							if (times[i] == minRuntime)
								bub.PrinterInColor(times[i], memories[i]);
							else
								bub.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "3")
						{
							mer.Namer();
							if (times[i] == minRuntime)
								mer.PrinterInColor(times[i], memories[i]);
							else
								mer.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "4")
						{
							qui.Namer();
							if (times[i] == minRuntime)
								qui.PrinterInColor(times[i], memories[i]);
							else
								qui.Printer(times[i], memories[i]);
						}
					}
				}
				else if (selection[1] == ',')
				{
					int counter = 0;
					long[] times = new long[2];
					long[] memories = new long[2];
					string[] calls = new string[2];
					void checker(string a)
					{
						if (a == "1")
						{
							calls[counter] = "1";
							ins.ReDistr(SortedNumarr, Numarr, n);
							ins.Sorting(SortedNumarr, n);
							times[counter] = ins.time;
							memories[counter] = ins.mem2 - ins.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (ins.time <= minRuntime)
									minRuntime = ins.time;
							}
							else
								minRuntime = ins.time;
						}
						else if (a == "2")
						{
							calls[counter] = "2";
							bub.ReDistr(SortedNumarr, Numarr, n);
							bub.Sorting(SortedNumarr, n);
							times[counter] = bub.time;
							memories[counter] = bub.mem2 - bub.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (bub.time <= minRuntime)
									minRuntime = bub.time;
							}
							else
								minRuntime = bub.time;
						}
						else if (a == "3")
						{
							calls[counter] = "3";
							mer.ReDistr(SortedNumarr, Numarr, n);
							mer.Sorting(SortedNumarr, 0, n - 1);
							times[counter] = mer.time;
							memories[counter] = mer.mem2 - mer.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (mer.time <= minRuntime)
									minRuntime = mer.time;
							}
							else
								minRuntime = mer.time;
						}
						else if (a == "4")
						{
							calls[counter] = "4";
							qui.ReDistr(SortedNumarr, Numarr, n);
							qui.Sorting(SortedNumarr, 0, n - 1);
							times[counter] = qui.time;
							memories[counter] = qui.mem2 - qui.mem1;
							counter++;
							if (minRuntime > 0)
							{
								if (qui.time <= minRuntime)
									minRuntime = qui.time;
							}
							else
								minRuntime = qui.time;
						}
					}
					checker(selection[0].ToString());
					checker(selection[2].ToString());
					for (int i = 0; i < calls.Length; i++)
					{
						if (calls[i] == "1")
						{
							ins.Namer();
							if (times[i] == minRuntime)
								ins.PrinterInColor(times[i], memories[i]);
							else
								ins.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "2")
						{
							bub.Namer();
							if (times[i] == minRuntime)
								bub.PrinterInColor(times[i], memories[i]);
							else
								bub.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "3")
						{
							mer.Namer();
							if (times[i] == minRuntime)
								mer.PrinterInColor(times[i], memories[i]);
							else
								mer.Printer(times[i], memories[i]);
						}
						else if (calls[i] == "4")
						{
							qui.Namer();
							if (times[i] == minRuntime)
								qui.PrinterInColor(times[i], memories[i]);
							else
								qui.Printer(times[i], memories[i]);
						}
					}
				}
			}
			else
			{
				int interval = 0;
				for (int i = 0; i < selection.Length; i += 2)
					interval++;
				int counter = 0;
				long[] times = new long[interval];
				long[] memories = new long[interval];
				string[] calls = new string[interval];
				for (int i = 0; i < selection.Length; i+=2)
				{
					if (selection[i].ToString() == "1")
					{
						calls[counter] = "1";
						ins.ReDistr(SortedNumarr, Numarr, n);
						ins.Sorting(SortedNumarr, n);
						times[counter] = ins.time;
						memories[counter] = ins.mem2 - ins.mem1;
						counter++;
						if (minRuntime > 0)
						{
							if (ins.time <= minRuntime)
								minRuntime = ins.time;
						}
						else
							minRuntime = ins.time;
					}
					else if (selection[i].ToString() == "2")
					{
						calls[counter] = "2";
						bub.ReDistr(SortedNumarr, Numarr, n);
						bub.Sorting(SortedNumarr, n);
						times[counter] = bub.time;
						memories[counter] = bub.mem2 - bub.mem1;
						counter++;
						if (minRuntime > 0)
						{
							if (bub.time <= minRuntime)
								minRuntime = bub.time;
						}
						else
							minRuntime = bub.time;
					}
					else if (selection[i].ToString() == "3")
					{
						calls[counter] = "3";
						mer.ReDistr(SortedNumarr, Numarr, n);
						mer.Sorting(SortedNumarr, 0, n - 1);
						times[counter] = mer.time;
						memories[counter] = mer.mem2 - mer.mem1;
						counter++;
						if (minRuntime > 0)
						{
							if (mer.time <= minRuntime)
								minRuntime = mer.time;
						}
						else
							minRuntime = mer.time;
					}
					else if (selection[i].ToString() == "4")
					{
						calls[counter] = "4";
						qui.ReDistr(SortedNumarr, Numarr, n);
						qui.Sorting(SortedNumarr, 0, n - 1);
						times[counter] = qui.time;
						memories[counter] = qui.mem2 - qui.mem1;
						counter++;
						if (minRuntime > 0)
						{
							if (qui.time <= minRuntime)
								minRuntime = qui.time;
						}
						else
							minRuntime = qui.time;
					}
				}
				for (int i = 0; i < calls.Length; i++)
				{
					if (calls[i] == "1")
					{
						ins.Namer();
						if (times[i] == minRuntime)
							ins.PrinterInColor(times[i], memories[i]);
						else
							ins.Printer(times[i], memories[i]);
					}
					else if (calls[i] == "2")
					{
						bub.Namer();
						if (times[i] == minRuntime)
							bub.PrinterInColor(times[i], memories[i]);
						else
							bub.Printer(times[i], memories[i]);
					}
					else if (calls[i] == "3")
					{
						mer.Namer();
						if (times[i] == minRuntime)
							mer.PrinterInColor(times[i], memories[i]);
						else
							mer.Printer(times[i], memories[i]);
					}
					else if (calls[i] == "4")
					{
						qui.Namer();
						if (times[i] == minRuntime)
							qui.PrinterInColor(times[i], memories[i]);
						else
							qui.Printer(times[i], memories[i]);
					}
				}
			}
			Console.ReadKey();
		}
	}
}

using System;
using System.Diagnostics;

namespace SortAlgo
{
    class CommonOper
    {
        public long mem, time;
        public string name = "";
        public void Namer(string name)
        {
            this.name = name;
        }
        public void ReDistr(int[] SortedArr, int[] PrimArr, int arrLength)
        {
            for (int p = 0; p < arrLength; p++)
                SortedArr[p] = PrimArr[p];
        }
        public void Printer(long jamanak, long hish)
        {
            Console.Write($"{this.name}\nRunning Time: {jamanak}ms\nMemory Usage: {hish}bytes\n\n");
        }
        public void PrinterInColor(long jamanak, long hish)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{this.name}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Running Time: {jamanak}ms\nMemory Usage: {hish}bytes\n\n");
        }
    }
    class Insertion : CommonOper
    {
        public void Sort(int[] SortedArr, int arrLength)
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
            Sort(SortedArr, arrLength);
            mem = GC.GetTotalMemory(false);
            st.Stop();
            time = st.ElapsedMilliseconds;
        }
    }
    class Bubble : CommonOper
    {
        public void Sort(int[] SortedArr, int arrLength)
        {
            for (int i = 0; i < arrLength - 1; i++)
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
            Sort(SortedArr, arrLength);
            mem = GC.GetTotalMemory(false);
            mergeSort(SortedArr, l, r);
            mem = GC.GetTotalMemory(false);
            st.Stop();
            time = st.ElapsedMilliseconds;
        }
    }
    class Quick : CommonOper
    {
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
            Sort(SortedArr, low, high);
            mem = GC.GetTotalMemory(false);
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
            long minRuntime = -1;
            string selection;
            Console.WriteLine("Please enter the size of an array you want to sort:");
            n = Convert.ToInt32(Console.ReadLine());
            int[] Numarr = new int[n];
            int[] SortedNumarr = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                Numarr[i] = rnd.Next(-2147483648, 2147483647);
            Console.Write("Select which algorithm you want to perform:\n1.Insertion Sort\n2.Bubble Sort\n3.Merge Sort\n4.Quick Sort\n5.All\n");
            selection = Console.ReadLine();
            if (selection.Length == 1)
            {
                if (selection == "1")
                {
                    ins.ReDistr(SortedNumarr, Numarr, n);
                    ins.Sorting(SortedNumarr, n);
                    ins.Namer("Insertion Sort:");
                    ins.Printer(ins.time, ins.mem);
                }
                else if (selection == "2")
                {
                    bub.ReDistr(SortedNumarr, Numarr, n);
                    bub.Sorting(SortedNumarr, n);
                    bub.Namer("Bubble Sort:");
                    bub.Printer(bub.time, bub.mem);
                }
                else if (selection == "3")
                {
                    mer.ReDistr(SortedNumarr, Numarr, n);
                    mer.Sorting(SortedNumarr, 0, n - 1);
                    mer.Namer("Merge Sort:");
                    mer.Printer(mer.time, mer.mem);
                }
                else if (selection == "4")
                {
                    qui.ReDistr(SortedNumarr, Numarr, n);
                    qui.Sorting(SortedNumarr, 0, n - 1);
                    qui.Namer("Quick Sort:");
                    qui.Printer(qui.time, qui.mem);
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
                            memories[counter] = ins.mem;
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
                            memories[counter] = bub.mem;
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
                            memories[counter] = mer.mem;
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
                            memories[counter] = qui.mem;
                            memories[counter] = ins.mem;
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
                            memories[counter] = bub.mem;
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
                            memories[counter] = mer.mem;
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
                            memories[counter] = qui.mem;
                            memories[counter] = ins.mem;
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
                            memories[counter] = bub.mem;
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
                            memories[counter] = mer.mem;
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
                            memories[counter] = qui.mem;
                        memories[counter] = ins.mem;
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
                        memories[counter] = bub.mem;
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
                        memories[counter] = mer.mem;
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
                        memories[counter] = qui.mem;
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
                        ins.Namer("Insertion Sort:");
                        if (times[i] == minRuntime)
                            ins.PrinterInColor(times[i], memories[i]);
                        else
                            ins.Printer(times[i], memories[i]);
                    }
                    else if (calls[i] == "2")
                    {
                        bub.Namer("Bubble Sort:");
                        if (times[i] == minRuntime)
                            bub.PrinterInColor(times[i], memories[i]);
                        else
                            bub.Printer(times[i], memories[i]);
                    }
                    else if (calls[i] == "3")
                    {
                        mer.Namer("Merge Sort:");
                        if (times[i] == minRuntime)
                            mer.PrinterInColor(times[i], memories[i]);
                        else
                            mer.Printer(times[i], memories[i]);
                    }
                    else if (calls[i] == "4")
                    {
                        qui.Namer("Quick Sort:");
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
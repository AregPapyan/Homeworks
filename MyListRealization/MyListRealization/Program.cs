using System;
using System.Collections;
using System.Collections.Generic;
namespace MyListRealization
{
	class MyEnumerator<T> : IEnumerator<T>
	{
		private T[] Myarr;
		private int position = -1;

		public MyEnumerator(T[] array)
		{
			this.Myarr = array;
		}

		public T Current
		{
			get
			{
				if (this.position < 0 || this.position >= this.Myarr.Length)
					throw new InvalidOperationException();
				return this.Myarr[this.position];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if (this.position < 0 || this.position >= this.Myarr.Length)
					throw new InvalidOperationException();
				return this.Myarr[this.position];
			}
		}
		public void Dispose()
		{

		}

		public bool MoveNext()
		{
			if (this.position < this.Myarr.Length - 1)
			{
				this.position++;
				return true;
			}
			else
				return false;
		}

		public void Reset()
		{
			position = -1;
		}
	}
	class MyList<T> : IEnumerable<T>
	{
		private T[] arr;
		private int pointer = 0;
		public T this[int i] { get { return this.arr[i]; } set { this.arr[i] = value; } }
		public IEnumerator<T> GetEnumerator()
		{
			return new MyEnumerator<T>(this.arr);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new MyEnumerator<T>(this.arr);
		}
		public void Add(T value)
		{
			this.arr[this.pointer] = value;
			this.pointer++;
		}
		public MyList(long length)
		{
			this.arr = new T[length];
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			MyList<int> a = new MyList<int>(20);
			for (int i = 1; i <= 18; i++)
			{
				a.Add(i);
			}
			a[18] = 2323;
			a[19] = 4545;
			foreach (int item in a)
			{
				Console.WriteLine(item * 2);
			}
			Console.ReadKey();
		}
	}
}
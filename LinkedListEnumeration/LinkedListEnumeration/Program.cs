using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerators
{
	public class Node : IEnumerable
	{
		public int value;
		public Node next;

		public Node(int item)
		{
			this.value = item;
		}

		public void Add(int item)
		{
			if (this.next == null)
			{
				this.next = new Node(item);
			}
			else
			{
				this.next.Add(item);
			}
		}

		public IEnumerator GetEnumerator()
		{
			return new NodeEnumerator(this);
		}

		public void PrintNode()
		{
			Console.WriteLine(this.value);
			if (this.next != null)
			{
				this.next.PrintNode();
			}
		}
	}
	class NodeEnumerator : IEnumerator
	{
		private Node first;
		//		private int position = -1;
		public object Current
		{
			get;
			private set;
		}


		public bool MoveNext()
		{
			//Node head = this.first;
			//for (int i = 0; i < position; i++)
			//{
			//	head = head.next;
			//}
			//if (head.next == null)
			//	return false;
			//else
			//{
			//	position++;
			//	return true;
			//}
			if (this.first == null)
				return false;
			else
			{
				this.Current = this.first;
				this.first = this.first.next;
				return true;
			}
		}

		public void Reset()
		{

		}

		public NodeEnumerator(Node first)
		{
			this.first = first;			
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Node prior = new Node(100);
			prior.Add(99);
			prior.Add(88);
			prior.Add(77);
			prior.Add(66);
			prior.Add(55);
			prior.Add(44);
			prior.Add(33);
			prior.Add(22);
			prior.Add(11);
			prior.Add(0);
			//prior.PrintNode();
			foreach (Node item in prior)
			{
				Console.WriteLine(item.value);
			}
			Console.ReadKey();
		}
	}
}

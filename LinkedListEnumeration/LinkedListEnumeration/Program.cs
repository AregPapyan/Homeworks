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
		private int position = -1;
		public object Current
		{
			get
			{
				Node head = this.first;
				for (int i = 0; i < position; i++)
				{
					head = head.next;
				}
				return head;
			}
		}


		public bool MoveNext()
		{
			Node head = this.first;
			for (int i = 0; i < position; i++)
			{
				head = head.next;
			}
			if (head.next == null)
				return false;
			else
			{
				position++;
				return true;
			}
		}

		public void Reset()
		{
			position = -1;
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
			prior.Add(90);
			prior.Add(80);
			prior.Add(70);
			prior.Add(60);
			prior.Add(50);
			prior.Add(40);
			prior.Add(30);
			prior.Add(20);
			prior.Add(10);
			//prior.PrintNode();
			foreach (Node item in prior)
			{
				Console.WriteLine(item.value);
			}
			Console.ReadKey();
		}
	}
}

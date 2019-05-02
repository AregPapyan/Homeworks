using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimap
{
	class Multi<TKey, TValue> : IDictionary<TKey, List<TValue>>
	{
		private Dictionary<TKey, List<TValue>> content;
		public List<TValue> this[TKey key] { get => this.content[key]; set => this.content[key]=value; }

		public ICollection<TKey> Keys => this.content.Keys;

		public ICollection<List<TValue>> Values => this.content.Values;

		public int Count => this.content.Count;

		public bool IsReadOnly =>false;

		public void Add(TKey key, List<TValue> value)
		{
			this.content.Add(key,value);
		}

		public void Add(KeyValuePair<TKey, List<TValue>> item)
		{
			this.content.Add(item.Key,item.Value);
		}
		public void Add(TKey key, TValue value)
		{
			this.content[key].Add(value);
		}
		public void Clear()
		{
			this.content.Clear();
		}

		public bool Contains(KeyValuePair<TKey, List<TValue>> item)
		{
			if (this.content.Contains(item))
				return true;
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return this.content.ContainsKey(key);
		}

		public void CopyTo(KeyValuePair<TKey, List<TValue>>[] array, int arrayIndex)
		{
			foreach (KeyValuePair<TKey, List<TValue>> pair in this.content)
			{
				array[arrayIndex] = pair;
				++arrayIndex;
			}
		}

		public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
		{
			return this.content.GetEnumerator();
		}

		public bool Remove(TKey key)
		{
			if (this.content.ContainsKey(key))
			{
				this.content.Remove(key);
				return true;
			}
			return false;
		}

		public bool Remove(KeyValuePair<TKey, List<TValue>> item)
		{
			if (this.content.Contains(item))
			{
				this.content.Remove(item.Key);
				return true;
			}
			return false;
		}

		public bool TryGetValue(TKey key, out List<TValue> value)
		{
			if (this.content.ContainsKey(key))
			{
				value = this.content[key];
				return true;
			}
			else
			{
				value = default(List<TValue>);
				return false;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.content.GetEnumerator();
		}
		public Multi()
		{
			this.content = new Dictionary<TKey, List<TValue>>();
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}

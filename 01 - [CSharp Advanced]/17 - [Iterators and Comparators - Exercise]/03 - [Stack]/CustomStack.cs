using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private List<T> list;

        public CustomStack()
        {
            this.list = new List<T>();
        }

        public int Count
        {
            get => this.list.Count;
        }

        public void Push(T item)
        {
            this.list.Add(item);
        }

        public T Pop()
        {
            T item = this.list[^1];
            this.list.RemoveAt(this.list.Count - 1);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

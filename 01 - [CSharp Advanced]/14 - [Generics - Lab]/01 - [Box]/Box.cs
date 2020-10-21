using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stack;

        public Box()
        {
            this.stack = new Stack<T>();
        }

        public int Count
        {
            get => this.stack.Count;
        }

        public void Add(T item)
        {
            this.stack.Push(item);
        }

        public T Remove()
        {
            return this.stack.Pop();
        }
    }
}

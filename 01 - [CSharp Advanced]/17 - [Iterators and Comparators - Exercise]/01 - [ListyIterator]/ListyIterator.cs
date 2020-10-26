using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;

        public ListyIterator(List<T> currList)
        {
            this.list = currList;
        }

        public int CurrentIndex { get; set; }

        public bool Move()
        {
            if (HasNext())
            {
                this.CurrentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.list.Count > this.CurrentIndex + 1;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.list[this.CurrentIndex]);
        }
    }
}

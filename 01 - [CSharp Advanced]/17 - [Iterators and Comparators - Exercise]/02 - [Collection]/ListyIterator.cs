using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
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
            CheckingForListCount();

            Console.WriteLine(this.list[this.CurrentIndex]);
        }

        public void PrintAll()
        {
            CheckingForListCount();

            Console.WriteLine(string.Join(" ", this.list));
        }

        private void CheckingForListCount()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

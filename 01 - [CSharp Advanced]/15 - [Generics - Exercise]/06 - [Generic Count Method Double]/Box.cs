using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfStrings
{
    public class Box<T> where T : IComparable
    {
        public List<T> List { get; set; }

        public Box(List<T> list)
        {
            this.List = list;
        }

        public int GetCount(T item)
        {
            int count = 0;

            foreach (var currItem in this.List)
            {
                if (currItem.CompareTo(item) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

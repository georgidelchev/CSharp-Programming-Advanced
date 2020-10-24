using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfStrings
{
    public class Box<T>
    {
        public List<T> List { get; set; }

        public Box(List<T> list)
        {
            this.List = list;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.List[firstIndex];
            this.List[firstIndex] = this.List[secondIndex];
            this.List[secondIndex] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.List)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}

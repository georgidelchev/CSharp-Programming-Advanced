using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> presentsList;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.presentsList = new List<Present>();
        }

        public string Color { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get => this.presentsList.Count;
        }

        public void Add(Present present)
        {
            if (this.Count < this.Capacity)
            {
                presentsList.Add(present);
            }
        }

        public bool Remove(string name)
        {
            Present present = this.presentsList.FirstOrDefault(x => x.Name == name);

            if (present != null)
            {
                this.presentsList.Remove(present);
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            Present present = this.presentsList.OrderByDescending(x => x.Weight).First();

            return present;
        }

        public Present GetPresent(string name)
        {
            Present present = this.presentsList.FirstOrDefault(x => x.Name == name);

            return present;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var item in this.presentsList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

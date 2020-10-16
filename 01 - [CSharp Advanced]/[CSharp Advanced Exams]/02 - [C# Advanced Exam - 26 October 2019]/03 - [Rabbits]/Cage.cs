using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> rabbitsList;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.rabbitsList = new List<Rabbit>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get => this.rabbitsList.Count;
        }

        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                this.rabbitsList.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            bool isRabbitExisting = false;

            if (rabbitsList.Any(x => x.Name == name))
            {
                isRabbitExisting = true;
                var rabbit = this.rabbitsList.Where(r => r.Name == name).FirstOrDefault();
            }

            return isRabbitExisting;
        }

        public void RemoveSpecies(string species)
        {
            this.rabbitsList.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.rabbitsList.FirstOrDefault(x => x.Name == name);

            rabbit.Available = false;

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var count = rabbitsList.Count(x => x.Species == species);
            var rabbitsToSell = new Rabbit[count];

            int counter = 0;

            foreach (var item in this.rabbitsList)
            {
                if (item.Species == species)
                {
                    rabbitsToSell[counter] = item;
                    item.Available = false;
                    counter++;
                }
            }

            return rabbitsToSell;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var item in this.rabbitsList)
            {
                if (item.Available == true)
                {
                    sb.AppendLine(item.ToString().Trim());
                }
            }

            return $"Rabbits available at {this.Name}:{Environment.NewLine}" +
                sb.ToString().Trim();
        }
    }
}

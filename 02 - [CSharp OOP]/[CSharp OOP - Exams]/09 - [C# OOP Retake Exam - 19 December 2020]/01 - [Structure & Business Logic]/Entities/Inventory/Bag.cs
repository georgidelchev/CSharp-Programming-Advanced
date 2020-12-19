using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load
            => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
            => this.items;

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (this.Items.All(i => i.GetType().Name != name))
            {
                var msg = string.Format(ExceptionMessages.ItemNotFoundInBag, name);

                throw new ArgumentException(msg);
            }

            var item = this.items.FirstOrDefault(i => i.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
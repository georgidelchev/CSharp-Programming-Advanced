using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : List<string>, IAdd, IRemove
    {
        public AddRemoveCollection()
        {
            AddOperations = new List<int>();
            RemoveOperations = new List<string>();
        }

        public List<int> AddOperations { get; private set; }

        public List<string> RemoveOperations { get; private set; }

        public new int Add(string item)
        {
            this.Insert(0, item);

            this.AddOperations.Add(0);

            return 0;
        }

        public string Remove()
        {
            string item = this[this.Count - 1];

            this.RemoveAt(this.Count - 1);

            this.RemoveOperations.Add(item);

            return item;
        }
    }
}

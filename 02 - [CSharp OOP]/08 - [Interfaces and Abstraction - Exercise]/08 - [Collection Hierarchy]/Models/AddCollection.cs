using CollectionHierarchy.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : Stack, IAdd
    {
        public AddCollection()
        {
            this.AddOperations = new List<int>();
        }

        public List<int> AddOperations { get; private set; }

        public int Add(string item)
        {
            this.Push(item);

            this.AddOperations.Add(this.Count - 1);

            return this.Count - 1;
        }
    }
}

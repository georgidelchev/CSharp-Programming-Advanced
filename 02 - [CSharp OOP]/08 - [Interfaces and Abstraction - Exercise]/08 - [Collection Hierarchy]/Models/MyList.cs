using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : List<string>, IUsed
    {
        public MyList()
        {
            this.AddOperations = new List<int>();
            this.RemoveOperations = new List<string>();
        }

        public List<int> AddOperations { get; set; }

        public List<string> RemoveOperations { get; set; }

        public int Used => this.Count;

        public new int Add(string item)
        {
            this.Insert(0, item);

            this.AddOperations.Add(0);

            return 0;
        }

        public string Remove()
        {
            string item = this[0];

            this.RemoveAt(0);

            this.RemoveOperations.Add(item);

            return item;
        }
    }
}

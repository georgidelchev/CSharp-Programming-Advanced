using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICheckable
    {
        public Citizen(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; private set; }

        public string Id { get; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}

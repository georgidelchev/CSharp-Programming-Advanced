using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClass.Models
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches =
            new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get
            {
                return this.sandwiches[name];
            }
            set
            {
                this.sandwiches.Add(name, value);
            }
        }
    }
}

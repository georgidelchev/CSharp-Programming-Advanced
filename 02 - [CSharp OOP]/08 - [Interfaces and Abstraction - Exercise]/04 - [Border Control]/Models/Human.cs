using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Human : Citizen, ICheckable
    {
        public Human(string name, int age, string id)
            : base(name, id)
        {
            this.Age = age;
        }

        public int Age { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person()
            : this("Unknown", 0)
        {

        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}

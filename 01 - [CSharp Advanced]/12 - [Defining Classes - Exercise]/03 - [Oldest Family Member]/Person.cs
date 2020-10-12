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
            : this("No name", 1)
        {

        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}

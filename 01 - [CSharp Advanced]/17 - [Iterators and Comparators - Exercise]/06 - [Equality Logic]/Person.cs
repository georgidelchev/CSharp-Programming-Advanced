using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            var comparison = this.Name.CompareTo(other.Name);

            if (comparison == 0)
            {
                comparison = this.Age.CompareTo(other.Age);
            }

            return comparison;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Person p)
            {
                return this.CompareTo(p) == 0;
            }

            return false;
        }
    }
}

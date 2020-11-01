using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (this.age < 0)
                {
                    throw new ArgumentException("Age canno't be less than 0.");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString().Trim();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData
{
    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Grade { get; set; }

        /// <summary>
        /// Overriding ToString().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"{this.Name} is {this.Age} years old.");

            if (this.Grade >= 5.00)
            {
                sb.Append(" Excellent student.");
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                sb.Append(" Average student.");
            }
            else
            {
                sb.Append(" Very nice person.");
            }

            return sb.ToString();
        }
    }
}

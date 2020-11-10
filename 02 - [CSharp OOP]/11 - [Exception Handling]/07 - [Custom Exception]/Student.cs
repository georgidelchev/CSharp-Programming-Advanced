using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    public class Student : Person
    {
        private string name;
        private string email;

        public Student(string firstName, string lastName, int age, string email)
            : base(firstName, lastName, age)
        {
            this.Email = email;
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Last name cannot be empty.");
                }

                this.email = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Email:{this.Email}";
        }
    }
}

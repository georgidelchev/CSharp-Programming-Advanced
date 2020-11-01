using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validation.ValidateNameCharsCount(value, "First");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validation.ValidateNameCharsCount(value, "Last");
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                Validation.ValidateAge(value, 0);
                this.age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                Validation.ValidateSalary(value, 460);
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            var divider = 100;

            if (this.Age < 30)
            {
                divider = 200;
            }

            this.Salary += this.Salary * percentage / divider;
        }


    }
}

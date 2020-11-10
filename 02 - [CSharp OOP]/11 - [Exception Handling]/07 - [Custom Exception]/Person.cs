using CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomException
{
    public class Person
    {
        private const string INVALID_NAME_MSG = "Invalid name.";
        private const string INVALID_FIRST_NAME_MSG = "First name cannot be empty.";
        private const string INVALID_LAST_NAME_MSG = "Last name cannot be empty.";
        private const string INVALID_AGE_MESSAGE = "Age must be in the range 0 - 120.";

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(INVALID_FIRST_NAME_MSG);
                }

                if (!value.All(x => char.IsLetter(x)))
                {
                    throw new InvalidPersonNameException(INVALID_NAME_MSG);
                }

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(INVALID_LAST_NAME_MSG);
                }

                if (!value.All(x => char.IsLetter(x)))
                {
                    throw new InvalidPersonNameException(INVALID_NAME_MSG);
                }

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
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException(INVALID_AGE_MESSAGE);
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName}{Environment.NewLine}{this.Age} yrs old person.";
        }
    }
}

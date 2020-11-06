using BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Human : Citizen, ICheckable, IBirthdate
    {
        public Human(string name, int age, string id, string birthdate)
            : base(name, id)
        {
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public int Age { get; private set; }

        public string Birthdate { get; }
    }
}

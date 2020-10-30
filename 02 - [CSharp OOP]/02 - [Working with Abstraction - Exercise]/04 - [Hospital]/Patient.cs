using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name.ToString().TrimEnd();
        }
    }
}

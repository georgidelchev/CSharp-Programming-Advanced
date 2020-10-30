using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {

        public Doctor()
        {
            this.Patients = new List<Patient>();
        }

        public Doctor(string firstName, string lastName)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FullName = firstName + lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public List<Patient> Patients { get; set; }

        public void AddPatient(Patient patient)
        {
            this.Patients.Add(patient);
        }
    }
}

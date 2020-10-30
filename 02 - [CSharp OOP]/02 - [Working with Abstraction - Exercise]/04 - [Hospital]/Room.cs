using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {

        public Room(byte number)
        {
            this.Number = number;
            this.Patients = new List<Patient>();
        }

        public byte Number { get; set; }

        public List<Patient> Patients;

        public int Count => this.Patients.Count;

        public void AddPatient(Patient patient)
        {
            if (this.Count < 3)
            {
                this.Patients.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients)
            {
                sb.AppendLine(patient.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

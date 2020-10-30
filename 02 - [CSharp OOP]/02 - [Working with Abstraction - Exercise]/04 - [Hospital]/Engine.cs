using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private List<Department> departments;
        private List<Doctor> doctors;

        public Engine()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }

        public void Proceed()
        {
            string command = "";
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command
                    .Split();

                string departmentName = tokens[0];
                string firstName = tokens[1];
                string lastName = tokens[2];
                string patientName = tokens[3];
                string fullName = firstName + lastName;

                if (!this.doctors.Any(x => x.FullName == fullName))
                {
                    this.doctors.Add(new Doctor(firstName, lastName));
                }
                if (!this.departments.Any(x => x.Name == departmentName))
                {
                    this.departments.Add(new Department(departmentName));
                }

                Doctor doctor = this.doctors
                    .FirstOrDefault(x => x.FullName == fullName);

                Department department = this.departments
                    .FirstOrDefault(x => x.Name == departmentName);

                bool isFree = department.Rooms
                    .Any(x => x.Count < 3);

                if (isFree)
                {
                    AddPatient(patientName, doctor, department);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command
                    .Split();

                if (args.Length == 1)
                {
                    PrintPatientsFromDepartment(args);
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int roomNum))
                {
                    PrintPatientsInRoom(args, roomNum);
                }
                else
                {
                    PrintingDoctorsPatients(args);
                }
            }
        }

        private void PrintPatientsFromDepartment(string[] args)
        {
            var department = this.departments
                             .FirstOrDefault(x => x.Name == args[0])
                             .Rooms
                             .Where(x => x.Count > 0);

            foreach (var item in department)
            {
                Console.WriteLine(item);
            }
        }

        private void PrintPatientsInRoom(string[] args, int roomNum)
        {
            Room room = this.departments
                                    .FirstOrDefault(x => x.Name == args[0])
                                    .Rooms
                                    .FirstOrDefault(x => x.Number == roomNum);

            Patient[] patientsInRoom = room
                .Patients
                .OrderBy(x => x.Name)
                .ToArray();

            foreach (var item in patientsInRoom)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void PrintingDoctorsPatients(string[] args)
        {
            Doctor doctor = this.doctors
                .FirstOrDefault(x => x.FullName == args[0] + args[1]);

            Patient[] doctorsPatients = doctor
                .Patients
                .OrderBy(x => x.Name)
                .ToArray();

            foreach (var item in doctorsPatients)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void AddPatient(string patientName, Doctor doctor, Department department)
        {
            Room firstFreeRoom = department.GetFirstFreeRoom();
            Patient patient = new Patient(patientName);
            firstFreeRoom.AddPatient(patient);
            doctor.AddPatient(patient);
        }
    }
}
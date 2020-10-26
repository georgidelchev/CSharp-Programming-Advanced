using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom
{
    public class Student
    {
        public Student(string firstName, string lastName, string subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Subject { get; }


        public override string ToString()
        {
            return $"Student: " +
                $"First Name = {this.FirstName}, " +
                $"Last Name = {this.LastName}," +
                $" Subject = {this.Subject}";
        }
    }
}

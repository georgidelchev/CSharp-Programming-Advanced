using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentData
{
    public class StudentData
    {
        public StudentData()
        {
            this.StudentsData = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> StudentsData { get; private set; }

        /// <summary>
        /// Getting details about the student.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <returns></returns>
        public string GetStudentDetails(string name)
        {
            if (!this.StudentsData.ContainsKey(name))
            {
                return null;
            }

            var student = this.StudentsData[name];

            return student.ToString();
        }

        /// <summary>
        /// Adding student.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="age">Student age.</param>
        /// <param name="grade">Student grade.</param>
        public void AddStudent(string name, int age, double grade)
        {
            if (!this.StudentsData.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.StudentsData[name] = student;
            }
        }
    }
}

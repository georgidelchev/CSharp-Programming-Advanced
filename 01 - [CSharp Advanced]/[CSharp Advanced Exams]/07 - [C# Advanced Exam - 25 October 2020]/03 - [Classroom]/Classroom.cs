using Classroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> studentsList;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.studentsList = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count
        {
            get => this.studentsList.Count;
        }

        public string RegisterStudent(Student student)
        {
            var result = "No seats in the classroom";

            if (this.Capacity > this.Count)
            {
                result = $"Added student {student.FirstName} {student.LastName}";
                this.studentsList.Add(student);
            }

            return result;
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var result = "Student not found";

            Student student = this.studentsList
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student != null)
            {
                this.studentsList.Remove(student);
                result = $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return result;
        }

        public string GetSubjectInfo(string subject)
        {

            var sb = new StringBuilder();
            var list = this.studentsList.Where(x => x.Subject == subject).ToList();

            if (!list.Any())
            {
                return "No students enrolled for the subject";
            }

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var item in list)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }

            return sb.ToString().Trim();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return
                this.studentsList
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}

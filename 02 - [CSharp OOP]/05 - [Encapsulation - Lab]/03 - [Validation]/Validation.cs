using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Validation
    {
        public static void ValidateNull<T>(T value)
        {
            if (value == null)
            {
                throw new ArgumentException($"{value} cannot be null.");
            }
        }

        public static void ValidateSalary<T>(T value, T minimum)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0)
            {
                throw new ArgumentException($"Salary cannot be less than 460 leva!");
            }
        }

        public static void ValidateAge<T>(T value, T age)
            where T : IComparable<T>
        {
            if (value.CompareTo(age) < 0)
            {
                throw new ArgumentException($"Age cannot be zero or a negative integer!");
            }
        }

        public static void ValidateNameCharsCount(string value, string type)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"{type} name cannot contain fewer than 3 symbols!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var listOfPeople = new List<Person>();

            var input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var splitted = input
                    .Split()
                    .ToList();

                var name = splitted[0];
                var age = int.Parse(splitted[1]);
                var town = splitted[2];

                listOfPeople.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine());

            int countOfMatches = 0;
            int numberOfNotEqualPeople = 0;
            int totalNumberOfPeople = listOfPeople.Count;

            foreach (var item in listOfPeople)
            {
                if (item.CompareTo(listOfPeople[n - 1]) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    numberOfNotEqualPeople++;
                }
            }

            Console.WriteLine(countOfMatches == 1 ? "No matches" :
                $"{countOfMatches} {numberOfNotEqualPeople} {totalNumberOfPeople}");
        }
    }
}

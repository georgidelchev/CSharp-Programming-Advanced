using BirthdayCelebrations.Interfaces;
using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        public void Proceed()
        {
            var citizensList = new List<IBirthdate>();

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                var type = splittedInput[0];
                var name = splittedInput[1];
                var id = "";
                var birthdate = "";

                if (type == "Citizen")
                {
                    int age = int.Parse(splittedInput[2]);
                    id = splittedInput[3];
                    birthdate = splittedInput[4];
                    citizensList.Add(new Human(name, age, id, birthdate));
                }
                else if (type == "Pet")
                {
                    birthdate = splittedInput[2];
                    citizensList.Add(new Pet(name, birthdate));
                }
            }

            var birthdateSearch = Console.ReadLine();
            citizensList.Where(x => x.Birthdate == birthdateSearch);

            foreach (var item in citizensList)
            {
                if (item.Birthdate.EndsWith(birthdateSearch))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}

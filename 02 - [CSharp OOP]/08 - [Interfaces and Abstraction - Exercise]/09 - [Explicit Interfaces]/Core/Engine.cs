using System;
using System.Linq;
using System.Text;
using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Proceed()
        {
            Citizen citizen = null;
            var sb = new StringBuilder();

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                var name = splittedInput[0];
                var country = splittedInput[1];
                var age = int.Parse(splittedInput[2]);

                citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                sb.AppendLine(person.GetName());
                sb.AppendLine(resident.GetName());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

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
            var citizensList = new List<ICheckable>();

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                var name = splittedInput[0];
                var id = "";

                if (splittedInput.Count == 3)
                {
                    int age = int.Parse(splittedInput[1]);
                    id = splittedInput[2];
                    citizensList.Add(new Human(name, age, id));
                }
                else
                {
                    id = splittedInput[1];
                    citizensList.Add(new Robot(name, id));
                }
            }

            var num = Console.ReadLine();

            foreach (var item in citizensList)
            {
                if (item.Id.EndsWith(num))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

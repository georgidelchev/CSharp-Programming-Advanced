using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var splittedInput = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = splittedInput[0];
                string carPlate = splittedInput[1];

                switch (command)
                {
                    case "IN":
                        set.Add(carPlate);
                        break;
                    case "OUT":
                        set.Remove(carPlate);
                        break;
                }
            }

            if (set.Count() == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, set));
            }
        }
    }
}

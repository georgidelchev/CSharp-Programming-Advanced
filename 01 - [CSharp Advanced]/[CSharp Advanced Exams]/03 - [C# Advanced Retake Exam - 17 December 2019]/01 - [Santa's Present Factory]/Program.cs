using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var materialsList = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

            var magicList = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

            Stack<int> materials = new Stack<int>(materialsList);
            Queue<int> magic = new Queue<int>(magicList);

            List<Toys> toys = new List<Toys>()
            {
                new Toys("Doll", 150),
                new Toys("Wooden train", 250),
                new Toys("Teddy bear", 300),
                new Toys("Bicycle", 400)
            };

            while (materials.Any() && magic.Any())
            {
                int sum = materials.Peek() * magic.Peek();
                
                if (toys.Any(p => p.MaterialsNeededToCraft == sum))
                {
                    toys.Find(p => p.MaterialsNeededToCraft == sum).ToysCount++;
                    materials.Pop();
                    magic.Dequeue();
                }
                else if (sum < 0)
                {
                    sum = materials.Peek() + magic.Peek();
                    materials.Pop();
                    magic.Dequeue();
                    materials.Push(sum);
                }
                else if (sum == 0)
                {
                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                    }
                    if (magic.Peek() == 0)
                    {
                        magic.Dequeue();
                    }
                }
                else
                {
                    materials.Push(materials.Pop() + 15);
                    magic.Dequeue();
                }
            }

            if ((toys.Where(p => p.ToyName == "Doll" && p.ToysCount > 0).Count() != 0
                && toys.Where(p => p.ToyName == "Wooden train"
                && p.ToysCount > 0).Count() != 0)
                || (toys.Where(p => p.ToyName == "Teddy bear"
                 && p.ToysCount > 0).Count() != 0
                && toys.Where(p => p.ToyName == "Bicycle"
                && p.ToysCount > 0).Count() != 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magic.Any())
            {
                Console.WriteLine($"Magic left: { string.Join(", ", magic)}");
            }

            foreach (var item in toys
                    .Where(p => p.ToysCount > 0)
                    .OrderBy(p => p.ToyName))
            {
                Console.WriteLine($"{item.ToyName}: {item.ToysCount}");
            }
        }
    }

    public class Toys
    {
        public Toys(string name, int materialsNeeded)
        {
            this.ToyName = name;
            this.MaterialsNeededToCraft = materialsNeeded;

        }

        public string ToyName { get; set; }
        public int MaterialsNeededToCraft { get; set; }
        public int ToysCount { get; set; }
    }
}
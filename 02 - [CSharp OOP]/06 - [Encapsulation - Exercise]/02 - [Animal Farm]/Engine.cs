using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm
{
    public class Engine
    {
        public void Proceed()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Chicken chicken = new Chicken(name, age);

                Console.WriteLine(chicken);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Engine
    {
        public void Proceed()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            IPerson person = new Citizen(name, age);

            Console.WriteLine(person);
        }
    }
}

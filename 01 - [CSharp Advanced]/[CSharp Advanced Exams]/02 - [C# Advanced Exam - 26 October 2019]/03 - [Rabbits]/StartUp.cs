using System;
using System.Linq;

namespace Rabbits
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository (Cage)
            Cage cage = new Cage("Wildness", 20);
            //Initialize entity
            Rabbit rabbit = new Rabbit("Fluffy", "Blanc de Hotot");
            //Print Rabbit
            Console.WriteLine(rabbit); //Rabbit (Blanc de Hotot): Fluffy

            //Add Rabbit
            cage.Add(rabbit);
            Console.WriteLine(cage.Count); //1
                                           //Remove Rabbit
            cage.RemoveRabbit("Rabbit Name"); //false

            Rabbit secondRabbit = new Rabbit("Bunny", "Brazilian");
            Rabbit thirdRabbit = new Rabbit("Jumpy", "Cashmere Lop");
            Rabbit fourthRabbit = new Rabbit("Puffy", "Cashmere Lop");
            Rabbit fifthRabbit = new Rabbit("Marlin", "Brazilian");

            //Add Rabbits
            cage.Add(secondRabbit);
            cage.Add(thirdRabbit);
            cage.Add(fourthRabbit);
            cage.Add(fifthRabbit);

            //Sell Rabbit by name
            Console.WriteLine(cage.SellRabbit("Bunny")); //Rabbit (Brazilian): Bunny
                                                         //Sell Rabbit by species
            Rabbit[] soldSpecies = cage.SellRabbitsBySpecies("Cashmere Lop");
            Console.WriteLine(string.Join(", ", soldSpecies.Select(f => f.Name))); //Jumpy, Puffy

            Console.WriteLine(cage.Report());
            //Rabbits available at Wildness:
            //Rabbit (Blanc de Hotot): Fluffy
            //Rabbit (Brazilian): Marlin

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Trainer>();

            string input = "";
            while ((input = Console.ReadLine()) != "Tournament")
            {
                var splitted = input
                    .Split()
                    .ToList();

                string trainerName = splitted[0];
                string pokemonName = splitted[1];
                string pokemonElement = splitted[2];
                int pokemonHealth = int.Parse(splitted[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!dict.ContainsKey(trainerName))
                {
                    dict[trainerName] = new Trainer(trainerName, 0);
                }

                dict[trainerName].PokemonsCollection.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var item in dict)
                {
                    if (item.Value.PokemonsCollection.Any(x => x.Element == input))
                    {
                        item.Value.NumberOfBadges++;
                    }
                    else
                    {
                        item.Value.PokemonsCollection.ForEach(x => x.Health -= 10);

                        item.Value.PokemonsCollection.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            foreach (var item in dict
                .OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}

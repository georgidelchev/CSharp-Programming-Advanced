using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int numberOfBadges)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> PokemonsCollection { get; set; } = new List<Pokemon>();

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.PokemonsCollection.Count}";
        }
    }
}

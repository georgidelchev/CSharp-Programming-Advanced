using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces.Animals;

namespace WildFarm.Models
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}

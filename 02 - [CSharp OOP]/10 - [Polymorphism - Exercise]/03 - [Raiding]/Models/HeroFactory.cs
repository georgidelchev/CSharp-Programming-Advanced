using Raiding.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string name, string type)
        {
            IHero hero = null;

            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");
                    break;
            }

            return hero;
        }
    }
}

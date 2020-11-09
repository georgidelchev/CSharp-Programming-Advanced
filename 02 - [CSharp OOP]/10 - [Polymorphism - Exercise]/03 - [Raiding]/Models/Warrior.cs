using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int DEFAULT_HERO_POWER = 100;

        public Warrior(string name)
            : base(name)
        {

        }

        public override int Power => DEFAULT_HERO_POWER;

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {this.Power} damage";
        }
    }
}

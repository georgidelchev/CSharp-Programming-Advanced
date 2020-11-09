using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int DEFAULT_HERO_POWER = 100;

        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power => DEFAULT_HERO_POWER;

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {this.Power}";
        }
    }
}

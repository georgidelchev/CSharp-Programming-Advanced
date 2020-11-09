using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int DEFAULT_HERO_POWER = 80;

        public Rogue(string name)
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

using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Interfaces
{
    public interface IHeroFactory
    {
        public IHero CreateHero(string name, string type);
    }
}

using Raiding.Core;
using Raiding.Interfaces;
using Raiding.IO;
using Raiding.Models;
using System;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IHeroFactory heroFactory = new HeroFactory();

            Engine engine = new Engine(reader, writer, heroFactory);

            engine.Proceed();
        }
    }
}

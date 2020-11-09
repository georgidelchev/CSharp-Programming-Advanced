using Raiding.Interfaces;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;
        IHeroFactory heroFactory;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
        }

        public void Proceed()
        {
            var raidGroup = new List<IHero>();

            var n = int.Parse(this.reader.ReadLine());
            var createdHeroes = 0;
            while (createdHeroes < n)
            {
                var name = this.reader.ReadLine();
                var type = this.reader.ReadLine();

                try
                {
                    var hero = this.heroFactory.CreateHero(name, type);
                    raidGroup.Add(hero);
                    createdHeroes++;
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            var bossHealth = int.Parse(this.reader.ReadLine());

            int totalDamage = CountingDamage(raidGroup);

            PrintResult(bossHealth, totalDamage);
        }

        private void CastAbility(IHero item)
         => this.writer.WriteLine(item.CastAbility());

        private int CountingDamage(List<IHero> raidGroup)
        {
            var totalDamage = 0;
            foreach (var item in raidGroup)
            {
                CastAbility(item);
                totalDamage += item.Power;
            }

            return totalDamage;
        }

        private void PrintResult(int bossHealth, int totalDamage)
        {
            var result = "";
            if (totalDamage >= bossHealth)
            {
                result = "Victory!";
            }
            else
            {
                result = "Defeat...";
            }

            this.writer.WriteLine(result);
        }
    }
}

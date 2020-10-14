using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroesList;
        public HeroRepository()
        {
            this.heroesList = new List<Hero>();
        }

        public List<Hero> HeroesList { get; set; }

        public int Count
        {
            get => this.heroesList.Count;
        }

        public void Add(Hero hero)
        {
            this.heroesList.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = this.heroesList.Find(x => x.Name == name);

            if (hero != null)
            {
                this.heroesList.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = this.heroesList
                .OrderByDescending(x => x.Item.Strength)
                .First();

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = this.heroesList
                .OrderByDescending(x => x.Item.Ability)
                .First();

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = this.heroesList
                .OrderByDescending(x => x.Item.Intelligence)
                .First();

            return hero;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in heroesList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}

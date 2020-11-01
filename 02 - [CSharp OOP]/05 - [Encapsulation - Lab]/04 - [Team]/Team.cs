using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;

            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }


        public IReadOnlyList<Person> FirstTeam => this.firstTeam;

        public IReadOnlyList<Person> ReserveTeam => this.reserveTeam;

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> playersList;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.playersList = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get => this.playersList.Count;
        }

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.Count)
            {
                this.playersList.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.playersList.Find(x => x.Name == name);

            if (player != null)
            {
                this.playersList.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = this.playersList.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.playersList.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string currClass)
        {
            var list = new List<Player>();

            foreach (var item in this.playersList)
            {
                if (item.Class == currClass)
                {
                    list.Add(item);
                }
            }

            this.playersList.RemoveAll(x => x.Class == currClass);

            return list.ToArray();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var item in this.playersList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

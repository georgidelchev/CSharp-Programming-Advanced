using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories.PlayersRepository
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            return this.players.Remove(player);
        }

        public IPlayer FindByName(string name)
        {
            return this.players.FirstOrDefault(p => p.Username == name);
        }
    }
}
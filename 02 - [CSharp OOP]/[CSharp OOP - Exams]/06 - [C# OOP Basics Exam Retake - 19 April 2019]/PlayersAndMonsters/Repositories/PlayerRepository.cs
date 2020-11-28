using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> _players;

        public PlayerRepository()
        {
            this._players = new List<IPlayer>();
        }

        public int Count
            => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players
                => this._players.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            PlayerNullValidation(player);

            if (this.Players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this._players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            PlayerNullValidation(player);

            return this._players.Remove(player);
        }

        public IPlayer Find(string username)
        {
            return this._players
                .FirstOrDefault(p => p.Username == username);
        }

        private static void PlayerNullValidation(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
        }
    }
}
using System;
using System.Reflection.Metadata;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string _username;
        private int _health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get => this._username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                this._username = value;
            }
        }

        public int Health
        {
            get => this._health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                this._health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (this.Health - damagePoints < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
    }
}
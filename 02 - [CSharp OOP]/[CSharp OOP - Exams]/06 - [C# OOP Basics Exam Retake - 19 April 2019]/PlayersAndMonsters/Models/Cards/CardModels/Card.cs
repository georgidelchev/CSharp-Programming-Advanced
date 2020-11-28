using System;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string _name;
        private int _damagePoints;
        private int _healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Card's name cannot be null or an empty string.");
                }

                this._name = value;
            }
        }

        public int DamagePoints
        {
            get => this._damagePoints; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }

                this._damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this._healthPoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }

                this._healthPoints = value;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> _cards;

        public CardRepository()
        {
            this._cards = new List<ICard>();
        }

        public int Count 
            => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards
            => this._cards.AsReadOnly();

        public void Add(ICard card)
        {
            CardNullValidation(card);

            if (this.Cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this._cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            CardNullValidation(card);

            return this._cards.Remove(card);
        }

        public ICard Find(string name)
        {
            return this._cards
                .FirstOrDefault(c => c.Name == name);
        }

        private static void CardNullValidation(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
        }
    }
}
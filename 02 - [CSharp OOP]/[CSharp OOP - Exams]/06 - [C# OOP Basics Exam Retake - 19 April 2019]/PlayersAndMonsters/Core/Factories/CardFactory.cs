using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.CardModels;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;
            switch (type)
            {
                case "Magic":
                    card = new MagicCard(name);
                    break;
                case "Trap":
                    card = new TrapCard(name);
                    break;
            }

            return card;
        }
    }
}
using System.Linq;
using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Models.BattleFields.BattleFieldModels;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.CardModels;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.PlayerModels;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playersRepository;
        private readonly ICardRepository cardsRepository;
        private readonly IBattleField battleField;

        private readonly IPlayerFactory playerFactory;
        private readonly ICardFactory cardFactory;

        public ManagerController()
        {
            this.playersRepository = new PlayerRepository();
            this.cardsRepository = new CardRepository();
            this.battleField = new BattleField();

            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);

            this.playersRepository.Add(player);

            var msg = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return msg;
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardsRepository.Add(card);

            var msg = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return msg;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playersRepository
                .Find(username);

            var card = this.cardsRepository
                .Find(cardName);

            player.CardRepository.Add(card);

            var msg = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return msg;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.playersRepository
                .Find(attackUser);

            var enemyPlayer = this.playersRepository
                .Find(enemyUser);

            battleField.Fight(attackPlayer, enemyPlayer);

            var msg = string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);

            return msg;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.playersRepository.Players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

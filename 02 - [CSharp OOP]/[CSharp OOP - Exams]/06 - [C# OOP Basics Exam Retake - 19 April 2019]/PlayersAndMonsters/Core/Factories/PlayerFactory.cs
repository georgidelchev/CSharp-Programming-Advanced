using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.PlayerModels;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;
            switch (type)
            {
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;
                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;
            }

            return player;
        }
    }
}
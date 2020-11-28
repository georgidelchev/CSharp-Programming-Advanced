using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields.BattleFieldModels
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead ||
                enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            IncreasePlayerStats(attackPlayer);
            IncreasePlayerStats(enemyPlayer);

            BonusIncreasePlayerDamage(attackPlayer);
            BonusIncreasePlayerDamage(enemyPlayer);

            PlayersFight(attackPlayer);
            PlayersFight(enemyPlayer);
        }

        private static void IncreasePlayerStats(IPlayer player)
        {
            if (player.GetType().Name.Equals(nameof(Beginner)))
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private static void BonusIncreasePlayerDamage(IPlayer player)
        {
            player.Health += player
                .CardRepository
                .Cards
                .Select(c => c.DamagePoints)
                .Sum();
        }

        private static void PlayersFight(IPlayer player)
        {
            foreach (var currPlayer in player.CardRepository.Cards)
            {
                if (player.Health <= 0)
                {
                    player.Health = 0;

                    break;
                }

                player.TakeDamage(currPlayer.DamagePoints);
            }
        }
    }
}
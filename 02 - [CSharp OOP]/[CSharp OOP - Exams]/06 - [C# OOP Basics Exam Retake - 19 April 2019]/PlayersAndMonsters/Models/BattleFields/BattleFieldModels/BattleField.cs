using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.PlayerModels;

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

            attackPlayer.Health += CalculatePlayerHealth(attackPlayer);
            enemyPlayer.Health += CalculatePlayerHealth(enemyPlayer);

            Fighting(attackPlayer, enemyPlayer);
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

        private static int CalculatePlayerHealth(IPlayer player)
            => player
                .CardRepository
                .Cards
                .Select(c => c.HealthPoints)
                .Sum();

        private static int CalculatePlayerDamage(IPlayer player)
            => player
                .CardRepository
                .Cards
                .Select(c => c.DamagePoints)
                .Sum();

        private static void Fighting(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            while (true)
            {
                var attackerAttackPoints = CalculatePlayerDamage(attackPlayer);

                enemyPlayer.TakeDamage(attackerAttackPoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyAttackPoints = CalculatePlayerDamage(enemyPlayer);

                attackPlayer.TakeDamage(enemyAttackPoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
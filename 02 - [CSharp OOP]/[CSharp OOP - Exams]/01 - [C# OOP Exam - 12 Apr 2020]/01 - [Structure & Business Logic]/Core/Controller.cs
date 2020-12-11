using System;
using System.Linq;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Guns.GunsModels;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Maps.MapModels;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.PlayersRepository;
using CounterStrike.Utilities.Enumerations;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (!Enum.TryParse(type, out Guns gun))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            guns.Add(CreateGun(name, bulletsCount, gun));

            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentNullException(ExceptionMessages.GunCannotBeFound);
            }

            if (!Enum.TryParse(type, out Players player))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            players.Add(CreatePlayer(username, health, armor, gun, player));

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string StartGame()
        {
            return map.Start(players.Models.ToList().Where(p => p.IsAlive));
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.players
                .Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}");
                sb.AppendLine($"--Health: {player.Health}");
                sb.AppendLine($"--Armor: {player.Armor}");
                sb.AppendLine($"--Gun: {player.Gun.Name}");
            }

            return sb.ToString().Trim();
        }

        private static IGun CreateGun(string name, int bulletsCount, Guns gun)
        {
            IGun gunToAdd = gun switch
            {
                Guns.Pistol => new Pistol(name, bulletsCount),
                Guns.Rifle => new Rifle(name, bulletsCount)
            };

            return gunToAdd;
        }

        private static IPlayer CreatePlayer(string username, int health, int armor, IGun gun, Players player)
        {
            IPlayer playerToAdd = player switch
            {
                Players.Terrorist => new Terrorist(username, health, armor, gun),
                Players.CounterTerrorist => new CounterTerrorist(username, health, armor, gun)
            };

            return playerToAdd;
        }
    }
}

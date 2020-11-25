namespace CounterStrike.Core.Contracts
{
    using CounterStrike.Models.Guns.Contracts;

    public interface IController
    {
        string AddGun(string type, string name, int bulletsCount);

        string AddPlayer(string type, string username, int health, int armor, string gunName);

        string StartGame();

        string Report();
    }
}

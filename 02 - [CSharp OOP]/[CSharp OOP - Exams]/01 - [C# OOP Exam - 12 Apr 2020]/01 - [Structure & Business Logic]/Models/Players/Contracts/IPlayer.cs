namespace CounterStrike.Models.Players.Contracts
{
    using CounterStrike.Models.Guns.Contracts;

    public interface IPlayer
    {
        string Username { get; }

        int Health { get; }

        int Armor { get; }

        IGun Gun { get; }

        bool IsAlive { get; }

        void TakeDamage(int points);
    }
}

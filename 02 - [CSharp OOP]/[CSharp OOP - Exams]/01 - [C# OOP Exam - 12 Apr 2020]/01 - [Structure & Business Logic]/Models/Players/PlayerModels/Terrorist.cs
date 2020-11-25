using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Players
{
    public class Terrorist : Player
    {
        public Terrorist(string username, int health, int armor, IGun gun) 
            : base(username, health, armor, gun)
        {
        }
    }
}
namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int INITIAL_DAMAGE_POINTS = 5;
        private const int INITIAL_HEALTH_POINTS = 80;

        public MagicCard(string name) 
            : base(name, INITIAL_DAMAGE_POINTS, INITIAL_HEALTH_POINTS)
        {
        }
    }
}
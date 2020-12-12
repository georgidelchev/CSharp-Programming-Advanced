namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal INITIAL_WATER_PRICE = 1.50m;

        public Water(string name, int portion, string brand)
            : base(name, portion, INITIAL_WATER_PRICE, brand)
        {
        }
    }
}
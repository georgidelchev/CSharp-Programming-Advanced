namespace CounterStrike.Models.Guns.GunsModels
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            var result = 0;

            if (this.BulletsCount >= 10)
            {
                this.BulletsCount -= 10;

                result = 10;
            }

            return result;
        }
    }
}
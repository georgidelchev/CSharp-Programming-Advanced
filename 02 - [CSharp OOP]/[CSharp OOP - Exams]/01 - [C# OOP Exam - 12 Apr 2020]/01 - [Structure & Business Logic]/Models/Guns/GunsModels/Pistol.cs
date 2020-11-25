namespace CounterStrike.Models.Guns.GunsModels
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            var result = 0;

            if (this.BulletsCount > 0)
            {
                this.BulletsCount--;

                result = 1;
            }

            return result;
        }
    }
}
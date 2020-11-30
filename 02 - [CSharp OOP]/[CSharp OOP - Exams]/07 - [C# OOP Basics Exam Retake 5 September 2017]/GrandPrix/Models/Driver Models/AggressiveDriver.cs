public class AggressiveDriver : Driver
{
    private const double DEFAULT_FUEL_CONSUMPTION_PER_KM = 2.7;
    private const double SPEED_MULTIPLIER = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, DEFAULT_FUEL_CONSUMPTION_PER_KM)
    {
    }

    public override double Speed
        => base.Speed * SPEED_MULTIPLIER;
}

public class EnduranceDriver : Driver
{
    private const double DEFAULT_FUEL_CONSUMPTION_PER_KM = 1.5;

    public EnduranceDriver(string name, Car car)
        : base(name, car, DEFAULT_FUEL_CONSUMPTION_PER_KM)
    {
    }
}

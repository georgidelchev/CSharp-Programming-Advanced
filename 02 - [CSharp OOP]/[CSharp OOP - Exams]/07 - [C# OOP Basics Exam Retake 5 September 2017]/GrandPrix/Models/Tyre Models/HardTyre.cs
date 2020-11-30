public class HardTyre : Tyre
{
    private const string DEFAULT_TIRE_NAME = "Hard";

    public HardTyre(double hardness)
        : base(DEFAULT_TIRE_NAME, hardness)
    {
    }
}

using System;

public class UltrasoftTyre : Tyre
{
    private const string DEFAULT_TIRE_NAME = "Ultrasoft";

    private double degradation;

    public UltrasoftTyre(double hardness, double grip)
        : base(DEFAULT_TIRE_NAME, hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; private set; }

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("The tire has blown.");
            }

            this.degradation = value;
        }
    }

    public override void DegradationReduce()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}
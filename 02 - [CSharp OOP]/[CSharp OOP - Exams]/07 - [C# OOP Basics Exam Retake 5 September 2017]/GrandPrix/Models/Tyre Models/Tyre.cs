using System;

public abstract class Tyre : ITyre
{
    private const int STARTING_TYRE_DEGRADATION = 100;

    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;

        this.Degradation = STARTING_TYRE_DEGRADATION;
    }

    public string Name { get; private set; }

    public double Hardness { get; private set; }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Tire degradation cannot be below zero.");
            }

            this.degradation = value;
        }
    }

    public virtual void DegradationReduce()
    {
        this.Degradation -= this.Hardness;
    }
}

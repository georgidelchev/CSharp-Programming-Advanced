using System;

public class Car : ICar
{
    private const int MAXIMUM_FUEL_AMOUNT = 160;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value > MAXIMUM_FUEL_AMOUNT)
            {
                this.fuelAmount = MAXIMUM_FUEL_AMOUNT;
                return;
            }

            if (value < 0)
            {
                throw new ArgumentException("Fuel cannot be below zero.");
            }

            this.fuelAmount = value;
        }
    }

    public Tyre Tyre { get; private set; }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void ReduceFuel(double fuel)
    {
        this.FuelAmount -= fuel;
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }
}

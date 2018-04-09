using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double FuelConsumption 
    {
        get { return base.FuelConsumption + 1.6; }
    }

    public override void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (this.TankCapacity - this.FuelQuantity < fuel)
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }
        this.FuelQuantity += fuel * 0.95;
    }
}
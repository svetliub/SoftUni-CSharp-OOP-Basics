using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }
    
    public virtual double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public void Drive(double distance)
    {
        if (distance * this.FuelConsumption > this.FuelQuantity)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
        this.FuelQuantity -= distance * this.FuelConsumption;
        Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
    }

    public virtual void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
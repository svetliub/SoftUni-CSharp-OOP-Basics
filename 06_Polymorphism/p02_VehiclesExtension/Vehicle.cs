using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = ValidateQuantity(fuelQuantity, tankCapacity);
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
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
    
    public double TankCapacity
    {
        get { return tankCapacity; }
        set { tankCapacity = value; }
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
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (this.TankCapacity - this.FuelQuantity < fuel)
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }
        this.FuelQuantity += fuel;
    }

    protected double ValidateQuantity(double fuelQuantity, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
        {
            return 0;
        }
        else
        {
            return fuelQuantity;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
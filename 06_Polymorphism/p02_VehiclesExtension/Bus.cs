using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public void DriveWithPeople(double distance)
    {
        if (distance * (this.FuelConsumption + 1.4) > this.FuelQuantity)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
        this.FuelQuantity -= distance * (this.FuelConsumption + 1.4);
        Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
    }
}
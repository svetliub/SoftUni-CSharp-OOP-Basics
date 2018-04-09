using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKilometer;
    private double traveledDistance;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumptionPerKilometer
    {
        get { return this.fuelConsumptionPerKilometer; }
        set { this.fuelConsumptionPerKilometer = value; }
    }

    public double TraveledDistance
    {
        get { return this.traveledDistance; }
        set { this.traveledDistance = value; }
    }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        this.TraveledDistance = 0;
    }

    public void Drive(double amountOfKm)
    {
        if (this.fuelAmount >= amountOfKm * this.FuelConsumptionPerKilometer)
        {
            this.FuelAmount -= amountOfKm * this.FuelConsumptionPerKilometer;
            this.TraveledDistance += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}


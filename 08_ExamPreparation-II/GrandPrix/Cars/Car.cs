using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private const double TANK_CAPACITY = 160;

    private double fuelAmount;

    public int Hp { get; }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = value;
        }
    }

    public Tyre Tyre { get; private set; }

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        Refuel(fuelAmount);
        this.Tyre = tyre;
    }

    public void Refuel(double fuelAmount)
    {
        if (this.FuelAmount + fuelAmount > TANK_CAPACITY)
        {
            this.FuelAmount = TANK_CAPACITY;
        }
        else
        {
            this.FuelAmount += fuelAmount;
        }
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    internal void CompleteLap(int truckLength, double fuelConsumption)
    {
        this.FuelAmount -= truckLength * fuelConsumption;

        this.Tyre.CompleteLap();
    }
}
public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
    {
    }

    public override double FuelConsumption 
    {
        get { return base.FuelConsumption + 1.6; }
    }

    public override void Refuel(double fuel)
    {
        this.FuelQuantity += fuel * 0.95;
    }
}
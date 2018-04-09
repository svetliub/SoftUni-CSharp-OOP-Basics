public class Cargo
{
    private int weight;
    private string cargoType;

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string CargoType
    {
        get { return this.cargoType; }
        set { this.cargoType = value; }
    }

    public Cargo(int weight, string cargoType)
    {
        this.Weight = weight;
        this.CargoType = cargoType;
    }
}
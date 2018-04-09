using System;

namespace P01_RawData
{
    public class Cargo
    {
        public int CargoWeight { get; set; }
        public CargoType CargoType { get; set; }

        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = Enum.Parse<CargoType>(cargoType);
        }
    }
}
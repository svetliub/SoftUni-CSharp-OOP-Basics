using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>(); 

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] inputLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = inputLine[0];
            int engineSpeed = int.Parse(inputLine[1]);
            int enginePower = int.Parse(inputLine[2]);
            int cargoWeight = int.Parse(inputLine[3]);
            string cargoType = inputLine[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            List<Tire> tires = new List<Tire>();

            for (int j = 5; j < inputLine.Length; j+=2)
            {
                Tire tire = new Tire(double.Parse(inputLine[j]), int.Parse(inputLine[j + 1]));
                tires.Add(tire);
            }

            Car tempCar = new Car(model, engine, cargo, tires);
            cars.Add(tempCar);
        }

        string typeOfCargo = Console.ReadLine();

        foreach (var car in cars.Where(c => c.Cargo.CargoType == typeOfCargo))
        {
            if (car.Cargo.CargoType == "fragile" && car.Tires.Any(t => t.Pressure < 1))
            {
                Console.WriteLine(car.Model);
            }
            else if (car.Cargo.CargoType == "flamable" && car.Engine.Power > 250)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}


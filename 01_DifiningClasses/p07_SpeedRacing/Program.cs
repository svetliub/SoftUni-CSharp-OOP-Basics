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
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = tokens[0];
            double fuelAmount = double.Parse(tokens[1]);
            double fuelConsumptionPerKilometer = double.Parse(tokens[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

            cars.Add(car);
        }

        string inputLine;

        while ((inputLine = Console.ReadLine()) != "End")
        {
            string[] driveTokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string model = driveTokens[1];
            double distance = double.Parse(driveTokens[2]);

            Car tempCar = cars.FirstOrDefault(c => c.Model == model);
            tempCar.Drive(distance);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
        }
    }
}


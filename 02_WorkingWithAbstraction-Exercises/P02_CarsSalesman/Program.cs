using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class CarSalesman
    {
        private static List<Car> cars;
        private static List<Engine> engines;
        static void Main(string[] args)
        {
            cars = new List<Car>();
            engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                AddEngine();
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                AddCar();
            }

            PrintCars();
        }

        private static string[] ReadParameters()
        {
            string[] parameters = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return parameters;
        }

        private static void AddEngine()
        {
            var parameters = ReadParameters();
            string model = parameters[0];
            int power = int.Parse(parameters[1]);
            int displacement = -1;
            string efficiency = "n/a";

            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                displacement = int.Parse(parameters[2]);
            }
            else if (parameters.Length == 3)
            {
                efficiency = parameters[2];
                displacement = -1;
            }
            else if (parameters.Length == 4)
            {
                efficiency = parameters[3];
                displacement = int.Parse(parameters[2]);
            }

            engines.Add(new Engine(model, power, displacement, efficiency));
        }

        private static void AddCar()
        {
            var parameters = ReadParameters();
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
            int weight = -1;
            string color = "n/a";

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                weight = int.Parse(parameters[2]);
            }
            else if (parameters.Length == 3)
            {
                color = parameters[2];
                weight = -1;
            }
            else if (parameters.Length == 4)
            {
                color = parameters[3];
                weight = int.Parse(parameters[2]);
            }

            cars.Add(new Car(model, engine, weight, color));
        }

        private static void PrintCars()
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

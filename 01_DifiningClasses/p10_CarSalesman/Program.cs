using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = tokens[0];
            int power = int.Parse(tokens[1]);
            int temp;
            string displacement = "n/a";
            string efficiency = "n/a";

            if (tokens.Length == 4)
            {
                displacement = tokens[2];
                efficiency = tokens[3];
            }
            else if (tokens.Length == 3)
            {
                bool tryParse = int.TryParse(tokens[2], out temp);

                if (tryParse)
                {
                    displacement = tokens[2];
                }
                else
                {
                    efficiency = tokens[2];
                }
            }

            Engine engine = new Engine(model, power, displacement, efficiency);

            engines.Add(engine);
        }

        int numberOfCars = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = carTokens[0];
            Engine engine = engines.FirstOrDefault(e => e.Model == carTokens[1]);
            string weigth = "n/a";
            string color = "n/a";
            int temp;

            if (carTokens.Length == 4)
            {
                weigth = carTokens[2];
                color = carTokens[3];
            }
            else if (carTokens.Length == 3)
            {
                bool tryParse = int.TryParse(carTokens[2], out temp);

                if (tryParse)
                {
                    weigth = carTokens[2];
                }
                else
                {
                    color = carTokens[2];
                }
            }

            Car car = new Car(model, engine, weigth, color);

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {car.Weight}");
            Console.WriteLine($"  Color: {car.Color}");
        }
    }
}


using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        var truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        var carFuelQuantity = double.Parse(carInput[1]);
        var carFuelConsumption = double.Parse(carInput[2]);
        var truckFuelQuantity = double.Parse(truckInput[1]);
        var truckFuelConsumption = double.Parse(truckInput[2]);

        Vehicle car = new Car(carFuelQuantity, carFuelConsumption);
        Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

        int numOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfCommands; i++)
        {
            try
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = tokens[0];
                var vehicle = tokens[1];
                var commandParameter = double.Parse(tokens[2]);

                switch (vehicle)
                {
                    case "Car":
                        if (command == "Drive")
                        {
                            car.Drive(commandParameter);
                        }
                        else if (command == "Refuel")
                        {
                            car.Refuel(commandParameter);
                        }
                        break;
                    case "Truck":
                        if (command == "Drive")
                        {
                            truck.Drive(commandParameter);
                        }
                        else if (command == "Refuel")
                        {
                            truck.Refuel(commandParameter);
                        }
                        break;
                        default:
                        throw new ArgumentException("Invalid vehicle!");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}
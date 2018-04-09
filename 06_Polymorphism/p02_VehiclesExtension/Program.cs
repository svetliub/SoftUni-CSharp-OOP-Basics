using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        var truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        var busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        var carFuelQuantity = double.Parse(carInput[1]);
        var carFuelConsumption = double.Parse(carInput[2]);
        var carTank = double.Parse(carInput[3]);
        var truckFuelQuantity = double.Parse(truckInput[1]);
        var truckFuelConsumption = double.Parse(truckInput[2]);
        var truckTank = double.Parse(truckInput[3]);
        var busFuelQuantity = double.Parse(busInput[1]);
        var busFuelConsumption = double.Parse(busInput[2]);
        var busTank = double.Parse(busInput[3]);

        Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTank);
        Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTank);
        Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTank);

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
                    case "Bus":
                        if (command == "Drive")
                        {
                            bus.DriveWithPeople(commandParameter);
                        }
                        else if (command == "Refuel")
                        {
                            bus.Refuel(commandParameter);
                        }
                        else if (command == "DriveEmpty")
                        {
                            bus.Drive(commandParameter);
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
        Console.WriteLine(bus);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    internal void Run()
    {
        while (true)
        {
            string[] commandArgs = Console.ReadLine().Split();
            string commandType = commandArgs[0];
            List<string> methodArgs = commandArgs.Skip(1).ToList();

            switch (commandType)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(methodArgs);
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(methodArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(methodArgs);
                    break;
                case "CompleteLaps":
                    string result = this.raceTower.CompleteLaps(methodArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                    default:
                        Console.WriteLine("Invalid command");
                    break;
            }

            if (this.raceTower.IsRaceOver)
            {
                break;
            }
        }
    }
}
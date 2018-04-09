using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Inhabitant> citizens = new List<Inhabitant>();

        AddInhabitant(citizens);

        PrintFakeId(citizens);
    }

    private static void PrintFakeId(List<Inhabitant> citizens)
    {
        var fakeId = Console.ReadLine();

        foreach (var citizen in citizens)
        {
            citizen.ValidateFakeId(fakeId);
        }
    }

    private static void AddInhabitant(List<Inhabitant> citizens)
    {
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();
            string name = tokens[0];

            if (tokens.Length == 3)
            {
                var age = int.Parse(tokens[1]);
                var id = tokens[2];

                Inhabitant citizen = new Citizen(name, id, age);
                citizens.Add(citizen);
            }
            else if (tokens.Length == 2)
            {
                var idRobot = tokens[1];

                Robot robot = new Robot(name, idRobot);
                citizens.Add(robot);
            }
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Inhabitant> creatures = new List<Inhabitant>();

        AddInhabitant(creatures);

        PrintFakeId(creatures);
    }

    private static void PrintFakeId(List<Inhabitant> creatures)
    {
        var year = Console.ReadLine();

        foreach (var creature in creatures)
        {
            if (creature.GetType().Name != "Robot")
            {
                creature.ValidateYearOfBirth(year);
            }
        }
    }

    private static void AddInhabitant(List<Inhabitant> creatures)
    {
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();
            string creatureТype = tokens[0];
            string name = tokens[1];

            if (creatureТype == "Citizen")
            {
                var age = int.Parse(tokens[2]);
                var id = tokens[3];
                var birthDate = tokens[4];

                Inhabitant citizen = new Citizen(name, id, age, birthDate);
                creatures.Add(citizen);
            }
            else if (creatureТype == "Pet")
            {
                var petDate = tokens[2];

                Inhabitant pet = new Pet(name, petDate);
                creatures.Add(pet);
            }
        }
    }
}
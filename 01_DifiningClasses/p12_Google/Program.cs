using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        string inputLine;

        while ((inputLine = Console.ReadLine()) != "End")
        {
            string[] tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string personName = tokens[0];
            string infoType = tokens[1];
            Person tempPerson = new Person(personName);

            if (people.All(p => p.FullName != personName))
            {
                people.Add(tempPerson);
            }
            else
            {
                tempPerson = people.FirstOrDefault(p => p.FullName == personName);
            }

            switch (infoType)
            {
                case "company":
                    string companyName = tokens[2];
                    string department = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);
                    Company company = new Company(companyName, department, salary);
                    tempPerson.Company = company;
                    break;
                case "car":
                    string carModel = tokens[2];
                    double speed = double.Parse(tokens[3]);
                    Car car = new Car(carModel, speed);
                    tempPerson.Car = car;
                    break;
                case "pokemon":
                    string pokemonName = tokens[2];
                    string pokemonType = tokens[3];
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                    tempPerson.AddPokemon(pokemon);
                    break;
                case "parents":
                    string parentName = tokens[2];
                    string birthDay = tokens[3];
                    Person parent = new Person(parentName, birthDay);
                    tempPerson.AddParent(parent);
                    break;
                case "children":
                    string childName = tokens[2];
                    string childBirthDay = tokens[3];
                    Person child = new Person(childName, childBirthDay);
                    tempPerson.AddChild(child);
                    break;
            }
        }

        string personInfoToPrint = Console.ReadLine();

        Person person = people.FirstOrDefault(p => p.FullName == personInfoToPrint);

        Console.WriteLine(person.FullName);
        Console.WriteLine($"Company:{person.Company}");
        Console.WriteLine($"Car:{person.Car}");
        Console.WriteLine("Pokemon:");
        foreach (var pokemon in person.Pokemons)
        {
            Console.WriteLine($"{pokemon.PokemonName} {pokemon.PokemonType}");
        }
        Console.WriteLine("Parents:");
        foreach (var parent in person.Parents)
        {
            Console.WriteLine($"{parent.FullName} {parent.BirthDay}");
        }
        Console.WriteLine("Children:");
        foreach (var child in person.Children)
        {
            Console.WriteLine($"{child.FullName} {child.BirthDay}");
        }
    }
}


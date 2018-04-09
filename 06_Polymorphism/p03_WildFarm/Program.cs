using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        string evenLine;
        while ((evenLine = Console.ReadLine()) != "End")
        {
            Animal animal = ParseAnimal(evenLine);
            animals.Add(animal);
            
            var oddLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Food food = ParseFood(oddLine);

            animal.ProducingSound();

            try
            {
                animal.TryEatFood(food);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static Animal ParseAnimal(string evenLine)
    {
        var animalInput = evenLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        var animalType = animalInput[0];
        var animalName = animalInput[1];
        var animalWeight = double.Parse(animalInput[2]);
        var fourtArgument = animalInput[3];

        Animal animal = null;

        switch (animalType)
        {
            case "Cat":
                var catBreed = animalInput[4];
                animal = new Cat(animalName, animalWeight, fourtArgument, catBreed);
                break;
            case "Tiger":
                var tigerBreed = animalInput[4];
                animal = new Tiger(animalName, animalWeight, fourtArgument, tigerBreed);
                break;
            case "Dog":
                animal = new Dog(animalName, animalWeight, fourtArgument);
                break;
            case "Mouse":
                animal = new Mouse(animalName, animalWeight, fourtArgument);
                break;
            case "Owl":
                double wingSize = double.Parse(fourtArgument);
                animal = new Owl(animalName, animalWeight, wingSize);
                break;
            case "Hen":
                double henWingSize = double.Parse(fourtArgument);
                animal = new Hen(animalName, animalWeight, henWingSize);
                break;
                default:
                    throw new ArgumentException("Invalid animal type!");
        }

        return animal;
    }

    private static Food ParseFood(string[] oddLine)
    {
        var foodType = oddLine[0];
        var foodQuantity = int.Parse(oddLine[1]);

        Food food = null;

        switch (foodType)
        {
            case "Meat":
                food = new Meat(foodQuantity);
                break;
            case "Vegetable":
                food = new Vegetable(foodQuantity);
                break;
            case "Fruit":
                food = new Fruit(foodQuantity);
                break;
            case "Seeds":
                food = new Seeds(foodQuantity);
                break;
                default:
                    throw new ArgumentException("Invalid type of food!");
        }

        return food;
    }
}
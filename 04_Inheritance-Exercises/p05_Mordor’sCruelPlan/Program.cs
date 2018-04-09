using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] foods = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
        Mordor foodFactory = new Mordor();

        for (int i = 0; i < foods.Length; i++)
        {
            foodFactory.AddFood(foods[i]);
        }

        Console.WriteLine(foodFactory.Happiness);
        Console.WriteLine(foodFactory.Mood);
    }
}
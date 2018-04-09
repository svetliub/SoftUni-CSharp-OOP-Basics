using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var peopleNumber = int.Parse(Console.ReadLine());
        List<Inhabitant> inhabitants = new List<Inhabitant>();

        for (int i = 0; i < peopleNumber; i++)
        {
            var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            if (tokens.Length == 4)
            {
                string id = tokens[2];
                string birthDate = tokens[3];

                Inhabitant citizen = new Citizen(name, age, id, birthDate);
                inhabitants.Add(citizen);
            }
            else if (tokens.Length == 3)
            {
                string group = tokens[2];

                Inhabitant rebel = new Rebel(name, age, group);
                inhabitants.Add(rebel);
            }
        }

        string buyerName;
        while ((buyerName = Console.ReadLine()) != "End")
        {
            Inhabitant buyer = inhabitants.FirstOrDefault(i => i.Name == buyerName);
            if (buyer != null)
            {
                buyer.BuyFood();
            }
        }

        Console.WriteLine(inhabitants.Sum(i => i.Food));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string breed = tokens[0];
            string name = tokens[1];
            Cat cat = null;

            switch (breed)
            {
                case "Siamese":
                    var earSize = int.Parse(tokens[2]);
                    cat = new Siamese(name, earSize);
                    break;
                case "Cymric":
                    var furLength = decimal.Parse(tokens[2]);
                    cat = new Cymric(name, furLength);
                    break;
                case "StreetExtraordinaire":
                    var decibelsOfMeows = int.Parse(tokens[2]);
                    cat = new StreetExtraordinaire(name, decibelsOfMeows);
                    break;
            }

            cats.Add(cat);
        }

        string catName = Console.ReadLine();

        Cat catToPrint = cats.First(c => c.Name == catName);

        Console.WriteLine(catToPrint);
    }
}


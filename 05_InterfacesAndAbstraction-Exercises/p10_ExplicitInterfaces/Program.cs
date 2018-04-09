using System;

class Program
{
    static void Main(string[] args)
    {
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();
            var name = tokens[0];
            var country = tokens[1];
            var age = int.Parse(tokens[2]);

            var citizen = new Citizen(name, country, age);
            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}
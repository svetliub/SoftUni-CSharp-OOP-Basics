using System;

class Program
{
    static void Main(string[] args)
    {
        var driver = Console.ReadLine();

        ICar ferrari = new Ferrari(driver);

        Console.WriteLine(ferrari);
    }
}
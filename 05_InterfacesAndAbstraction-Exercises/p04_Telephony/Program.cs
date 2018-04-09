using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> numbers = Console.ReadLine().Split().ToList();
        List<string> sites = Console.ReadLine().Split().ToList();
        Smartphone smartphone = new Smartphone();

        for (int i = 0; i < numbers.Count; i++)
        {
            try
            {
                smartphone.AddNumber(numbers[i]);
                smartphone.CallNumber(numbers[i]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        for (int i = 0; i < sites.Count; i++)
        {
            var site = sites[i];
            try
            {
                smartphone.AddAddresss(site);
                smartphone.BrowseAddress(site);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            ParsePeople(persons);
            ParseProducts(products);
            BuyProducts(persons, products);

            foreach (var person in persons)
            {
                Console.Write($"{person.Name} - ");
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", person.BagOfProducts));
                }
                else
                {
                    Console.WriteLine("Nothing bought");
                }
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void BuyProducts(List<Person> persons, List<Product> products)
    {
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Person buyer = persons.FirstOrDefault(p => p.Name == tokens[0]);
            Product productToBuy = products.FirstOrDefault(pr => pr.Name == tokens[1]);

            buyer.BuyProduct(productToBuy);
        }
    }

    private static void ParsePeople(List<Person> persons)
    {
        string[] inputPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        foreach (var pair in inputPeople)
        {
            var tokens = pair.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = tokens[0];
            decimal money = decimal.Parse(tokens[1]);
            Person person = new Person(name, money);
            persons.Add(person);
        }
    }

    private static void ParseProducts(List<Product> products)
    {
        string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        foreach (var pair in productsInput)
        {
            var tokens = pair.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = tokens[0];
            decimal price = decimal.Parse(tokens[1]);
            Product product = new Product(name, price);
            products.Add(product);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] pizzaInput = Console.ReadLine().Split(' ').ToArray();
            var pizzaName = pizzaInput[1];
            Pizza pizza = new Pizza(pizzaName);
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dough dough = new Dough(input[1], input[2], double.Parse(input[3]));

            List<Topping> toppings = new List<Topping>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] inputTopping = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Topping topping = new Topping(inputTopping[1], double.Parse(inputTopping[2]));
                toppings.Add(topping);
            }

            pizza = new Pizza(pizzaName, dough, toppings);

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

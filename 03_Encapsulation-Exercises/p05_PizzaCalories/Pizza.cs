using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private double totalCalories;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }
    
    public List<Topping> Toppings
    {
        get { return this.toppings; }
        set
        {
            if (value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings = value;
        }
    }

    public Dough Dough { get; set; }
    
    public double TotalCalories
    {
        get { return totalCalories; }
    }

    public Pizza(string name)
    {
        this.Name = name;
    }

    public Pizza(string name, Dough dough, List<Topping> toppings):this(name)
    {
        this.Dough = dough;
        this.Toppings = toppings;
        this.totalCalories = SetTotalCalories();
    }

    double SetTotalCalories()
    {
        double allCalories = this.Dough.Calories;
        foreach (var top in this.Toppings)
        {
            allCalories += top.Calories;
        }
        return allCalories;
    }
}


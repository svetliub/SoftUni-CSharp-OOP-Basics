using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private ToppingType toppingType;
    private double weight;
    private double calories;

    public ToppingType ToppingType
    {
        get { return toppingType; }
        set { toppingType = value; }
    }

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public double Calories
    {
        get { return calories; }
    }

    public Topping(string toppingType, double weight)
    {
        if (!Enum.IsDefined(typeof(ToppingType), toppingType.ToLower()))
        {
            throw new ArgumentException($"Cannot place {toppingType} on top of your pizza.");
        }
        this.ToppingType = Enum.Parse<ToppingType>(toppingType.ToLower());
        if (weight < 1 || weight > 50)
        {
            throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
        }
        this.Weight = weight;
        this.calories = SetToppingCalories();
    }

    private double SetToppingCalories()
    {
        var cal = 2 * this.Weight * (double)(Enum.Parse<ToppingType>(this.ToppingType.ToString())) / 10;
        return cal;
    }
}


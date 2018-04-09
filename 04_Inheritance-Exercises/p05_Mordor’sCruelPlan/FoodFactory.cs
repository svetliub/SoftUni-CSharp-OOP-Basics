using System;
using System.Collections.Generic;
using System.Linq;

public class FoodFactory
{
    private int happiness;
    private List<int> foods;
    
    public int Happiness
    {
        get { return foods.Sum(); }
    }
    
    public FoodFactory()
    {
        this.foods = new List<int>();
    }

    public void AddFood(string food)
    {
        if (Enum.IsDefined(typeof(FoodType), food.ToLower()))
        {
            foods.Add((int)(Enum.Parse<FoodType>(food.ToLower())));
        }
        else
        {
            foods.Add((int)(Enum.Parse<FoodType>("other")));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Mordor
{
    private int happiness;
    private List<int> foods;
    private string mood;

    public int Happiness
    {
        get { return foods.Sum(); }
    }

    public string Mood
    {
        get { return GetMood(); }
    }

    public Mordor()
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

    string GetMood()
    {
        if (this.Happiness < -5)
        {
            return "Angry";
        }
        else if (this.Happiness >= -5 && this.Happiness <= 0)
        {
            return "Sad";
        }
        else if (this.Happiness >= 1 && this.Happiness <= 15)
        {
            return "Happy";
        }
        else
        {
            return "JavaScript";
        }
    }
}
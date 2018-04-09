using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private const string DOUGH_EXEPTION_MESSAGE = "Invalid type of dough.";

    private FlourType flourType;
    private BakingTechnique bakingTechnique;
    private double weight;
    private double calories;

    public FlourType FlourType
    {
        get { return this.flourType; }
        set { this.flourType = value; }
    }

    public BakingTechnique BakingTechnique
    {
        get { return this.bakingTechnique; }
        set { this.bakingTechnique = value; }
    }

    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 0 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public double Calories
    {
        get { return this.calories; }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        if (!Enum.IsDefined(typeof(FlourType), flourType.ToLower()))
        {
            throw new ArgumentException(DOUGH_EXEPTION_MESSAGE);
        }
        this.FlourType = Enum.Parse<FlourType>(flourType.ToLower());
        if (!Enum.IsDefined(typeof(BakingTechnique), bakingTechnique.ToLower()))
        {
            throw new ArgumentException(DOUGH_EXEPTION_MESSAGE);
        }
        this.BakingTechnique = Enum.Parse<BakingTechnique>(bakingTechnique.ToLower());
        this.Weight = weight;
        this.calories = SetCalories();
    }

    private double SetCalories()
    {
        var cal = 2 * this.Weight * (double)(Enum.Parse<FlourType>(this.FlourType.ToString())) *
                        (double)Enum.Parse<BakingTechnique>(this.BakingTechnique.ToString()) / 100;
        return cal;
    }
}

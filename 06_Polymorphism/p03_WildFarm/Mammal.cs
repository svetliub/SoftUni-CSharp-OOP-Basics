﻿public abstract class Mammal : Animal
{
    public Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; set; }

    public override string ToString()
    {
        return base.ToString() + "{0}" + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
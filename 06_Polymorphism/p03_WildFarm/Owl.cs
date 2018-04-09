using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override Type[] PreferredFoods => new Type[]{typeof(Meat)};

    protected override double WeightIncreaseMultiplier => 0.25;

    public override void ProducingSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}
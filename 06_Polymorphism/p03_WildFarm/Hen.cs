using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override double WeightIncreaseMultiplier { get { return 0.35; } } //=> 0.35;

    public override void ProducingSound()
    {
        Console.WriteLine("Cluck");
    }
}
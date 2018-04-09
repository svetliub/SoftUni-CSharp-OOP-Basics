using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override Type[] PreferredFoods => new Type[]{typeof(Vegetable), typeof(Fruit)};

    protected override double WeightIncreaseMultiplier => 0.1;

    public override void ProducingSound()
    {
        Console.WriteLine("Squeak");
    }

    public override string ToString()
    {
        return string.Format(base.ToString(), string.Empty);
    }
}
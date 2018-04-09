using System;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override Type[] PreferredFoods => new Type[]{typeof(Vegetable), typeof(Meat)};

    protected override double WeightIncreaseMultiplier => 0.3;

    public override void ProducingSound()
    {
        Console.WriteLine("Meow");
    }
}
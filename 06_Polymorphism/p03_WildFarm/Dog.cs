using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override Type[] PreferredFoods => new Type[]{typeof(Meat)};

    protected override double WeightIncreaseMultiplier => 0.4;

    public override void ProducingSound()
    {
        Console.WriteLine("Woof!");
    }

    public override string ToString()
    {
        return string.Format(base.ToString(), string.Empty);
    }
}
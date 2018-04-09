using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override Type[] PreferredFoods => new Type[]{typeof(Meat)};

    public override void ProducingSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}
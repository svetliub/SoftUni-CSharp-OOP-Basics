using System;
using System.Collections.Generic;
using System.Text;

public abstract class Inhabitant : IBuyer
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int Food { get; set; }

    public Inhabitant(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public virtual void BuyFood()
    {
        this.Food += 0;
    }

    //internal void ValidateYearOfBirth(string year)
    //{
    //    if (this.BirthDate.EndsWith(year))
    //    {
    //        Console.WriteLine(this.BirthDate);
    //    }
    //}
}

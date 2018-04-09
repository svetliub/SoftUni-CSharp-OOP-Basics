using System;

public abstract class Inhabitant
{
    public string Name { get; set; }

    public string BirthDate { get; set; }

    public Inhabitant(string name, string birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    internal void ValidateYearOfBirth(string year)
    {
        if (this.BirthDate.EndsWith(year))
        {
            Console.WriteLine(this.BirthDate);
        }
    }
}
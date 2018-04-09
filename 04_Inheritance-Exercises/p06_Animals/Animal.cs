using System;
using System.Collections.Generic;
using System.Text;

public class Animal : ISoundProducable
{
    private const string ErrorMessage = "Invalid input!";

    private string name;
    private int age;
    private string gender;

    public string Name
    {
        get { return this.name; }
        set
        {
            NotEmptyValidation(value);
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessage);
            }
            this.age = value;
        }
    }

    public string Gender
    {
        get { return this.gender; }
        set
        {
            NotEmptyValidation(value);
            this.gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public virtual string ProduceSound()
    {
        return "NOISE!!!!!";
    }

    private static void NotEmptyValidation(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(ErrorMessage);
        }
    }

    public override string ToString()
    {
        StringBuilder sbBuilder = new StringBuilder();
        sbBuilder.AppendLine(this.GetType().Name);
        sbBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
        sbBuilder.AppendLine(ProduceSound());

        return sbBuilder.ToString().TrimEnd();
    }
}
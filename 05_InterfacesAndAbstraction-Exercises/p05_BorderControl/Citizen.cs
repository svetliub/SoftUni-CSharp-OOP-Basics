using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : Inhabitant
{
    public int Age { get; set; }

    public Citizen(string name, string id, int age) : base (name, id)
    {
        this.Age = age;
    }
}
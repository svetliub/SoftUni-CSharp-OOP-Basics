using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : Inhabitant
{
    public string Id { get; set; }

    public int Age { get; set; }
    
    public Citizen(string name, string id, int age, string birthDate) : base (name, birthDate)
    {
        this.Age = age;
        this.Id = id;
    }
}
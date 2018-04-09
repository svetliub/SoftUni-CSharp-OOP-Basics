using System;
using System.Collections.Generic;
using System.Text;

public abstract class Inhabitant
{
    public string Name { get; set; }

    public string Id { get; set; }

    public Inhabitant(string name, string id)
    {
        this.Name = name;
        this.Id = id;
    }

    public void ValidateFakeId(string id)
    {
        if (this.Id.EndsWith(id))
        {
            Console.WriteLine(this.Id);   
        }
    }
}
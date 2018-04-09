using System;
using System.Collections.Generic;
using System.Text;

public class Soldier : ISoldier
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Soldier(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
    }
}
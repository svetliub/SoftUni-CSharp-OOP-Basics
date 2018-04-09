using System;
using System.Collections.Generic;
using System.Text;

public class StreetExtraordinaire : Cat
{
    private int decibelsOfMeows;

    public int DecibelsOfMeows
    {
        get { return this.decibelsOfMeows; }
        set { this.decibelsOfMeows = value; }
    }

    public StreetExtraordinaire(string name, int decibelsOfMeows)
    {
        this.Name = name;
        this.DecibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.DecibelsOfMeows}";
    }
}


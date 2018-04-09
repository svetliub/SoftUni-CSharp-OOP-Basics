using System;
using System.Collections.Generic;
using System.Text;

public class Cymric : Cat
{
    private decimal furLength;

    public decimal FurLength
    {
        get { return this.furLength; }
        set { this.furLength = value; }
    }

    public Cymric(string name, decimal furLength)
    {
        this.Name = name;
        this.FurLength = furLength;
    }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurLength:f2}";
    }
}


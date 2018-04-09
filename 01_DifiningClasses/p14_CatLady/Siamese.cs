using System;
using System.Collections.Generic;
using System.Text;

public class Siamese : Cat
{
    private int earSize;

    public int EarSize
    {
        get { return this.earSize; }
        set { this.earSize = value; }
    }

    public Siamese(string name, int earSize)
    {
        this.Name = name;
        this.EarSize = earSize;
    }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.earSize}";
    }
}


using System;
using System.Collections.Generic;
using System.Text;

public abstract class Structure
{
    protected Structure(string id)
    {
        this.Id = id;
    }

    public string Id { get; private set; }

    public abstract string Type { get; }
    
    internal static void ValidateNonNegative(string message, double value, string propertyName)
    {
        if (value < 0)
        {
            throw new ArgumentException(string.Format(message, propertyName));
        }
    }
}
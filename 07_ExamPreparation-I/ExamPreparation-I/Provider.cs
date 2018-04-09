using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Structure
{
    private const string UNSUCCESSFULL_REGISTER_MESSAGE = "Provider is not registered, because of it's {0}";
    private double energyOutput;

    public Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public virtual double EnergyOutput
    {
        get { return this.energyOutput; }
        private set
        {
            ValidateNonNegative(UNSUCCESSFULL_REGISTER_MESSAGE, value, "EnergyOutput");
            if (value >= 10000)
            {
                throw new ArgumentException(string.Format(UNSUCCESSFULL_REGISTER_MESSAGE, "EnergyOutput"));
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{Type} Provider - {Id}" + Environment.NewLine +
               $"Energy Output: {EnergyOutput}";
    }
}
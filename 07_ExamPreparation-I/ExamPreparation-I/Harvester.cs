using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Structure
{
    private const string UNSUCCESSFULL_REGISTER_MESSAGE = "Harvester is not registered, because of it's {0}";
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public virtual double OreOutput
    {
        get { return this.oreOutput; }
        private set
        {
            ValidateNonNegative(UNSUCCESSFULL_REGISTER_MESSAGE, value, "OreOutput");
            this.oreOutput = value;
        }
    }

    public virtual double EnergyRequirement
    {
        get { return this.energyRequirement; }
        private set
        {
            ValidateNonNegative(UNSUCCESSFULL_REGISTER_MESSAGE, value, "EnergyRequirement");
            if (value > 20000)
            {
                throw new ArgumentException(string.Format(UNSUCCESSFULL_REGISTER_MESSAGE, "EnergyRequirement"));
            }
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        return $"{Type} Harvester - {Id}" + Environment.NewLine +
               $"Ore Output: {OreOutput}" + Environment.NewLine +
               $"Energy Requirement: {EnergyRequirement}";
    }
}
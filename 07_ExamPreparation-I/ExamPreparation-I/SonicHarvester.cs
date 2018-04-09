public class SonicHarvester : Harvester
{
    private int sonicFactor;
    public override string Type => "Sonic";

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput,
        energyRequirement)
    {
        this.SonicFactor = sonicFactor;
    }

    public override double EnergyRequirement
    {
        get { return base.EnergyRequirement / this.SonicFactor; }
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        set { sonicFactor = value; }
    }

}
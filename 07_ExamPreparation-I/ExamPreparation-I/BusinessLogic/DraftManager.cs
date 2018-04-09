using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.mode = "Full";
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = this.harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ax)
        {
            return ax.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = this.providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ax)
        {
            return ax.Message;
        }
    }

    public string Day()
    {
        double dayEnergyProvided = providers.Sum(p => p.EnergyOutput);
        this.totalEnergyStored += dayEnergyProvided;
        double dayEnergyRequired;
        double dayMinedOre;

        if (this.mode == "Full")
        {
            dayEnergyRequired = harvesters.Sum(h => h.EnergyRequirement);
            dayMinedOre = harvesters.Sum(h => h.OreOutput);
        }
        else if (mode == "Half")
        {
            dayEnergyRequired = harvesters.Sum(h => h.EnergyRequirement) * 0.6;
            dayMinedOre = harvesters.Sum(h => h.OreOutput) * 0.5;
        }
        else
        {
            dayEnergyRequired = 0;
            dayMinedOre = 0;
        }

        double realDayMinedOre = 0;
        if (totalEnergyStored >= dayEnergyRequired)
        {
            totalMinedOre += dayMinedOre;
            totalEnergyStored -= dayEnergyRequired;
            realDayMinedOre = dayMinedOre;
        }

        return "A day has passed." + Environment.NewLine +
               $"Energy Provided: {dayEnergyProvided}" + Environment.NewLine +
               $"Plumbus Ore Mined: {realDayMinedOre}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var unit = (Structure)harvesters.FirstOrDefault(h => h.Id == id) ?? providers.FirstOrDefault(p => p.Id == id);
        if (unit != null)
        {
            return unit.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
               $"Total Energy Stored: {totalEnergyStored}" + Environment.NewLine +
               $"Total Mined Plumbus Ore: {totalMinedOre}";
    }
}
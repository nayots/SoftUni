using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DraftManager
{
    private string currentMode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        this.currentMode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.harvesters.Add(this.harvesterFactory.Get(arguments));
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.providers.Add(this.providerFactory.Get(arguments));
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    public string Day()
    {
        double totalEnergyNeeded = 0;
        double summedOreOutput = 0;
        double summedEnergyOutput = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += summedEnergyOutput;
        switch (this.currentMode)
        {
            case "Full":
                totalEnergyNeeded = this.harvesters.Sum(h => h.EnergyRequirement);
                if (this.totalStoredEnergy >= totalEnergyNeeded)
                {
                    summedOreOutput = this.harvesters.Sum(h => h.OreOutput);
                    this.totalMinedOre += summedOreOutput;
                    this.totalStoredEnergy -= totalEnergyNeeded;
                }
                break;

            case "Half":
                totalEnergyNeeded = this.harvesters.Sum(h => h.EnergyRequirement) * 0.60;
                if (this.totalStoredEnergy >= totalEnergyNeeded)
                {
                    summedOreOutput = this.harvesters.Sum(h => h.OreOutput) * 0.50;
                    this.totalMinedOre += summedOreOutput;
                    this.totalStoredEnergy -= totalEnergyNeeded;
                }
                break;

            case "Energy":
                break;

            default:
                break;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {summedEnergyOutput}");
        sb.Append($"Plumbus Ore Mined: {summedOreOutput}");

        return sb.ToString();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        this.currentMode = mode;

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (this.harvesters.Any(h => h.Id == id))
        {
            return this.harvesters.First(h => h.Id == id).ToString();
        }

        if (this.providers.Any(p => p.Id == id))
        {
            return this.providers.First(p => p.Id == id).ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }
}
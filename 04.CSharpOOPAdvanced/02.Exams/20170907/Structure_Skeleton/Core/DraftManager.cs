using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class DraftManager : IManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private Dictionary<string, IHarvester> harvestersById;
    private Dictionary<string, IProvider> providersById;

    public DraftManager()
    {
        this.mode = "Full";
        this.totalMinedOre = 0;
        this.totalStoredEnergy = 0;
        this.harvestersById = new Dictionary<string, IHarvester>();
        this.providersById = new Dictionary<string, IProvider>();
    }

    public string Register(IList<string> arguments)
    {
        MethodInfo registerMethod = this.GetType().GetMethod("Register" + arguments[0]);
        arguments.RemoveAt(0);
        return (string)registerMethod.Invoke(this, new object[] { arguments });
    }

    public string RegisterHarvester(IList<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);
        var sonicFactor = 0;
        if (arguments.Count == 5)
        {
            sonicFactor = int.Parse(arguments[4]);
        }

        try
        {
            IHarvesterFactory fac = new HarvesterFactory();
            IHarvester harvester = fac.GenerateHarvester(arguments);
            this.harvestersById.Add(id, harvester);
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(IList<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = int.Parse(arguments[2]);

        try
        {
            IProviderFactory fac = new ProviderFactory();
            IProvider provider = fac.GenerateProvider(arguments);
            this.providersById.Add(id, provider);
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        //calculate provided power for the day
        double producedPower = 0;
        foreach (var provider in this.providersById)
        {
            producedPower += provider.Value.EnergyOutput;
        }

        //add to the total energy
        this.totalStoredEnergy += producedPower;

        //calculate needed energy
        double neededEnergy = 0;
        foreach (var harvester in this.harvestersById)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.Value.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.Value.EnergyRequirement * 60 / 100;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.totalStoredEnergy >= neededEnergy)
        {
            //mine
            this.totalStoredEnergy -= neededEnergy;
            foreach (var harvester in this.harvestersById)
            {
                minedOres += harvester.Value.OreOutput;
            }
        }

        //take the mode in mind
        if (this.mode == "Energy")
        {
            minedOres = 0;
        }
        else if (this.mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.totalMinedOre += minedOres;

        var sb = new StringBuilder();

        sb.AppendLine($"A day has passed.");
        sb.AppendLine($"Energy Provided: {producedPower}");
        sb.Append($"Plumbus Ore Mined: {minedOres}");

        return sb.ToString().Trim();
    }

    public string Mode(IList<string> arguments)
    {
        var mode = arguments[0];
        this.mode = mode;

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Repair(IList<string> arguments)
    {
        return "repair";
    }

    public string Inspect(IList<string> arguments)
    {
        var id = arguments[0];
        var sb = new StringBuilder();
        if (this.providersById.ContainsKey(id))
        {
            sb.AppendLine(providersById[id].ToString());
        }
        if (this.harvestersById.ContainsKey(id))
        {
            sb.AppendLine(harvestersById[id].ToString());
        }
        if (string.IsNullOrWhiteSpace(sb.ToString()))
        {
            sb.AppendLine($"No entity found with id - {id}");
        }

        return sb.ToString().Trim();
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }
}

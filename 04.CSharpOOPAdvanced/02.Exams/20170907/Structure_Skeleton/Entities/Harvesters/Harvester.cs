﻿public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability { get; protected set; }

    public double Produce()
    {
        return this.OreOutput;
    }

    public void Broke()
    {
        this.Durability -= 100;
    }
}
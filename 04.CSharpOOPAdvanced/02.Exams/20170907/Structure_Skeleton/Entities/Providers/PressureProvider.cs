public class PressureProvider : Provider
{
    private const int DurabilityDecrement = 300;
    private const int EnergyOutputMultiplier  = 2;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability = base.Durability - DurabilityDecrement;
        this.EnergyOutput = base.EnergyOutput * EnergyOutputMultiplier;
    }
}
public class SolarProvider : Provider
{
    private const int DurabilityIncrement = 500;

    public SolarProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability = base.Durability + DurabilityIncrement;
    }
}
public class Provider : IProvider
{
    private const int InitialDurability = 1000;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double Durability { get; protected set; }

    public double EnergyOutput { get; protected set; }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= 100;
    }


    public void Repair(double val)
    {
        this.Durability += val;
    }
}
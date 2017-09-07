namespace Minedraft.Core.Repositories
{
    public class EnergyRepository : IEnergyRepository
    {
        public double EnergyStored { get; private set; }

        public bool TakeEnergy(double energyNeeded)
        {
            if (this.EnergyStored >= energyNeeded)
            {
                this.EnergyStored -= energyNeeded;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StoreEnergy(double energy)
        {
            this.EnergyStored += energy;
        }
    }
}
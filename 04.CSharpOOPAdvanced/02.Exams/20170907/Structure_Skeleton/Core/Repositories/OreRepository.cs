namespace Minedraft.Core.Repositories
{
    public class OreRepository : IOreRepository
    {
        public double OreStored { get; private set; }

        public void StoreOre(double ore)
        {
            this.OreStored += ore;
        }
    }
}
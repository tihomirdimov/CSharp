public interface IOreRepository
{
    double OreStored { get; }

    void StoreOre(double ore);
}
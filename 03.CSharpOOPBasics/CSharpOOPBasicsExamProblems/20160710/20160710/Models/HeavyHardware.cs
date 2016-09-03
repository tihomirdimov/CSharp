namespace _20160710.Models
{
    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string name, int maximumCapacity, int maximumMemory) : base(name)
        {
            this.MaximumCapacity = maximumCapacity * 2;
            this.MaximumMemory = maximumMemory - (int)(maximumMemory / 100 * 25);
            this.Type = "Heavy";
        }
    }
}

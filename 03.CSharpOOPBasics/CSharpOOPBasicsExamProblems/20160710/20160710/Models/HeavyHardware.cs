namespace _20160710.Models
{
    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string name, string type, int maximumCapacity, int maximumMemory) : base(name, type, maximumCapacity, maximumMemory)
        {
            this.MaximumCapacity = (int)2 * maximumCapacity;
            this.MaximumMemory = (int)0.75 * maximumMemory;
        }
    }
}

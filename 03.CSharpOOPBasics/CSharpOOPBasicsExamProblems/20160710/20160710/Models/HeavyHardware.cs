namespace _20160710.Models
{
    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string name, int maximumCapacity, int maximumMemory) : base(name, maximumCapacity, maximumMemory)
        {
            this.MaximumCapacity = (int)2 * maximumCapacity;
            this.MaximumMemory = (int)0.75 * maximumMemory;
            this.Type = "heavy";
        }
    }
}

namespace _20160710.Models
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string name, string type, int maximumCapacity, int maximumMemory) : base(name, type, maximumCapacity, maximumMemory)
        {
            this.MaximumCapacity = (int)0.25 * maximumCapacity;
            this.MaximumMemory = (int)1.75 * maximumMemory;
        }
    }
}

namespace _20160710.Models
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string name, int maximumCapacity, int maximumMemory) : base(name)
        {
            this.MaximumCapacity = (int)0.25 * maximumCapacity;
            this.MaximumMemory = (int)1.75 * maximumMemory;
            this.Type = "power";
        }
    }
}

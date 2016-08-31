namespace _20160710.Models
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string name, int maximumCapacity, int maximumMemory) : base(name)
        {
            this.MaximumCapacity = maximumCapacity - (int)(maximumCapacity / 100 * 75);
            this.MaximumMemory = maximumMemory + (int)(maximumMemory / 100 * 75);
            this.Type = "power";
        }
    }
}

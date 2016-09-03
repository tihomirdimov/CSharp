namespace _20160710.Models
{
    public class Software : Component
    {
        public Software(string hardware, string name, int capacityConsumption, int memoryConsumption) : base(name)
        {
            this.Hardware = hardware;
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }
        public string Hardware { get; set; }
        public int CapacityConsumption { get; set; }
        public int MemoryConsumption { get; set; }
    }
}

namespace _20160710.Models
{
    public class Software : Component
    {
        public Software(string name, int capacityConsumption, int memoryConsumption) : base(name)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }
        public int CapacityConsumption { get; set; }
        public int MemoryConsumption { get; set; }
    }
}

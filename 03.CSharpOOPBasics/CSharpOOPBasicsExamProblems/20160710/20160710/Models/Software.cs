namespace _20160710.Models
{
    public class Software : Component
    {
        public Software(string name, string type, int capacityConsumption, int memoryConsumption) : base(name, type)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }
        public int CapacityConsumption { get; set; }
        public int MemoryConsumption { get; set; }
    }
}

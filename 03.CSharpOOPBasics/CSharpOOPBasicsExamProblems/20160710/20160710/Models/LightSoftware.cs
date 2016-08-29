namespace _20160710.Models
{
    class LightSoftware : Software
    {
        public LightSoftware(string name, string type, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
        {
            this.CapacityConsumption = (int)1.5 * capacityConsumption;
            this.MemoryConsumption = (int)0.5 * memoryConsumption;
            this.Type = "light";
        }
    }
}

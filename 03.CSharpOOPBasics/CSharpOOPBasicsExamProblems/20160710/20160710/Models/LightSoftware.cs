namespace _20160710.Models
{
    class LightSoftware : Software
    {
        public LightSoftware(string hardware, string name, int capacityConsumption, int memoryConsumption) : base(hardware, name, capacityConsumption, memoryConsumption)
        {
            this.CapacityConsumption = (int)1.5 * capacityConsumption;
            this.MemoryConsumption = (int)0.5 * memoryConsumption;
            this.Type = "light";
        }
    }
}

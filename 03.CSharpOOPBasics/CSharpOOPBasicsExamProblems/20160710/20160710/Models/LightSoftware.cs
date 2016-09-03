namespace _20160710.Models
{
    class LightSoftware : Software
    {
        public LightSoftware(string hardware, string name, int capacityConsumption, int memoryConsumption) : base(hardware, name, capacityConsumption, memoryConsumption)
        {
            this.CapacityConsumption = capacityConsumption + (int)(capacityConsumption / 100 * 50);
            this.MemoryConsumption = memoryConsumption - (int)(memoryConsumption / 100 * 50);
            this.Type = "Light";
        }
    }
}

namespace _20160710.Models
{
    public class ExpressSoftware : Software
    {
        public ExpressSoftware(string hardware, string name, int capacityConsumption, int memoryConsumption) : base(hardware, name, capacityConsumption, memoryConsumption)
        {
            this.MemoryConsumption = (int)memoryConsumption * 2;
            this.Type = "express";
        }
    }
}

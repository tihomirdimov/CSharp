namespace _20160710.Models
{
    class ExpressSoftware : Software
    {
        public ExpressSoftware(string name, string type, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
        {
            this.MemoryConsumption = (int)2 * memoryConsumption;
            this.Type = "express";
        }
    }
}

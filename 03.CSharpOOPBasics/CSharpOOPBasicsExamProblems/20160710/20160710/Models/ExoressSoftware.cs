namespace _20160710.Models
{
    class ExoressSoftware : Software
    {
        public ExoressSoftware(string name, string type, int capacityConsumption, int memoryConsumption) : base(name, type)
        {
            this.MemoryConsumption = (int)2 * memoryConsumption;
        }
    }
}

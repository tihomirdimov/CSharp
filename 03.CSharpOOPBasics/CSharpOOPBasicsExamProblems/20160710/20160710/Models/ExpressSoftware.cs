namespace _20160710.Models
{
    public class ExpressSoftware : Software
    {
        private int capacityConsumption;
        private int memoryConsumption;
        public ExpressSoftware(string hardware, string name, int capacityConsumption, int memoryConsumption)
            : base(hardware, name)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
            this.Type = "Express";
        }
        public override int CapacityConsumption
        {
            get
            {
                return capacityConsumption;
            }
            set
            {
                this.capacityConsumption = value;
            }
        }
        public override int MemoryConsumption
        {
            get
            {
                return memoryConsumption;
            }
            set
            {
                this.memoryConsumption = value * 2;
            }
        }
    }
}

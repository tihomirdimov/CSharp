namespace _20160710.Models
{
    public class LightSoftware : Software
    {
        private int capacityConsumption;
        private int memoryConsumption;
        public LightSoftware(string hardware, string name, int capacityConsumption, int memoryConsumption)
            : base(hardware, name)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
            this.Type = "Light";
        }

        public override int CapacityConsumption
        {
            get
            {
                return capacityConsumption;
            }
            set
            {
                this.capacityConsumption = value + (value / 2);
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
                this.memoryConsumption = value - value / 2;
            }
        }
    }
}

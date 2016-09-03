namespace _20160710.Models
{
    public class Software : Component
    {
        public Software(string hardware, string name) : base(name)
        {
            this.Hardware = hardware;
        }
        public int CapacityConsumption { get; set; }
        public int MemoryConsumption { get; set; }
        public string Hardware { get; set; }
    }
}

namespace _20160710.Models
{
    public abstract class Software : Component
    {
        protected Software(string hardware, string name) : base(name)
        {
            this.Hardware = hardware;
        }
        public string Hardware { get; set; }
        public virtual int CapacityConsumption { get; set; }
        public virtual int MemoryConsumption { get; set; }
    }
}

namespace _20160710.Models
{
    using System.Collections.Generic;
    public class Hardware : Component
    {
        public Hardware(string name) : base (name)
        {
            this.Software = new List<Software>();
        }
        public int MaximumCapacity { get; set; }
        public int MaximumMemory { get; set; }
        public List<Software> Software { get; set; }
    }
}
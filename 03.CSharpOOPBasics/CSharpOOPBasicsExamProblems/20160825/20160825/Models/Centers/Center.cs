namespace _20160825.Models.Centers
{
    using System.Collections.Generic;
    using Animals;
    public abstract class Center
    {
        protected Center(string name)
        {
            this.Name = name;
            StoredAnimals = new List<Animal>();
        }
        public string Name { get; protected set; }
        public int Type {get; protected set; }
        public List<Animal> StoredAnimals { get; set; }
    }
}
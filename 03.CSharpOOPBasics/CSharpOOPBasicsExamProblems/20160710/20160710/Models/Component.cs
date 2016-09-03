namespace _20160710.Models
{
    public abstract class Component
    {
        protected Component(string name)
        {
            this.Name = name;
        }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
    }
}

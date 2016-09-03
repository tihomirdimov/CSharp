namespace _20160710.Models
{
    public abstract class Component
    {
        protected Component(string name)
        {
            this.Name = name;
        }
        public string Name { get; protected set; }
        public string Type { get; set; }
    }
}

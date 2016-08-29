namespace _20160710.Models
{
    public abstract class Component
    {
        protected Component(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
        public string Name { get; protected set; }
        public string Type { get; protected set; }
    }
}

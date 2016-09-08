namespace _20160307.Models
{
    public class Ninja
    {
        private readonly string name;
        private int power;
        private int stamina;
        public Ninja(string name)
        {
            this.Name = name;
        }
        public string Name { get; }
        public string Power { get; set; }
        public string Stamina { get; set; }
    }
}

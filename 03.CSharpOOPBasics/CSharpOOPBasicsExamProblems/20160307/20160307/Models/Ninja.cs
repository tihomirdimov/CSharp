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
            this.Power = 1;
            this.Stamina = 1;
        }
        public string Name { get; }
        public int Power { get; set; }
        public int Stamina { get; set; }
    }
}

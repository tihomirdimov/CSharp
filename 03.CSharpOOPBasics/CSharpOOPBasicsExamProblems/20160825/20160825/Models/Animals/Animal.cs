namespace _20160825.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, int age, string adoptionCenter)
        {
            this.Name = name;
            this.Age = age;
            this.AdoptionCenter = adoptionCenter;
            this.Cleansed = false;
        }
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string AdoptionCenter { get; protected set; }
        public bool Cleansed { get; set; }
    }
}

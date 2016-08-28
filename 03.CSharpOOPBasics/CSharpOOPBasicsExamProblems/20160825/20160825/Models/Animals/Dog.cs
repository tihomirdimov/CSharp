namespace _20160825.Models.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, int commands, string adoptionCenter) : base(name, age, adoptionCenter)
        {
            this.Commands = commands;
        }
        public int Commands { get; }
    }
}

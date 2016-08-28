namespace _20160825.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, int intelligence, string adoptionCenter ) : base(name, age, adoptionCenter)
        {
            this.Intelligence = intelligence;
        }
        public int Intelligence { get; }
    }
}

namespace _20160825.Commands
{
    using Models.Animals;
    using Models.Centers;
    public class RegisterDog : Command
    {
        private Dog dog;
        public RegisterDog(Dog dog)
        {
            this.dog = dog;
        }
        public override void Execute()
        {
            PawInc.AdoptionCenters.Find(c=>c.Name.Equals(dog.AdoptionCenter)).StoredAnimals.Add(dog);
        }
    }
}
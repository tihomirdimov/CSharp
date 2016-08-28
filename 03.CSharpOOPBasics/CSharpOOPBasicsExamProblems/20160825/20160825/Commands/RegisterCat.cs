namespace _20160825.Commands
{
    using Models.Animals;
    using Models.Centers;
    public class RegisterCat : Command
    {
        private Cat cat;
        public RegisterCat(Cat cat)
        {
            this.cat = cat;
        }
        public override void Execute()
        {
            PawInc.AdoptionCenters.Find(c => c.Name.Equals(cat.AdoptionCenter)).StoredAnimals.Add(cat);
        }
    }
}
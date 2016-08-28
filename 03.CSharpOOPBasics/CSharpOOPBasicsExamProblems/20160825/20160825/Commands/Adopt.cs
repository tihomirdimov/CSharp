namespace _20160825.Commands
{
    using Models.Centers;
    using Models.Animals;
    using System.Collections.Generic;
    using System.Linq;
    public class Adopt : Command
    {
        private string adoptionCenter;
        public Adopt(string adoptionCenter)
        {
            this.adoptionCenter = adoptionCenter;
        }
        public override void Execute()
        {
            List<Animal> temp = PawInc.AdoptionCenters.Find(c => c.Name.Equals(this.adoptionCenter)).StoredAnimals.Where(a => a.Cleansed == true).ToList();
            PawInc.AdoptionCenters.Find(c => c.Name.Equals(this.adoptionCenter)).StoredAnimals.RemoveAll(a => a.Cleansed == true);
            foreach (var animal in temp)
            {
                PawInc.Adopted.Add(animal);
            }
        }
    }
}

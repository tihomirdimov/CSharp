namespace _20160825.Commands
{
    using Models.Centers;
    using Models.Animals;
    using System.Collections.Generic;
    using System.Linq;
    public class Cleanse : Command
    {
        private string cleansingCenter;
        public Cleanse(string cleansingCenter)
        {
            this.cleansingCenter = cleansingCenter;
        }
        public override void Execute()
        {
            List<Animal> temp = PawInc.CleansingCenters.Find(c => c.Name.Equals(this.cleansingCenter)).StoredAnimals.ToList();
            foreach (var animal in temp)
            {
                animal.Cleansed = true;
                PawInc.Cleansed.Add(animal);
                PawInc.AdoptionCenters.Find(c => c.Name.Equals(animal.AdoptionCenter)).StoredAnimals.Add(animal);
            }
            PawInc.CleansingCenters.Find(c => c.Name.Equals(this.cleansingCenter)).StoredAnimals.Clear();
        }
    }
}
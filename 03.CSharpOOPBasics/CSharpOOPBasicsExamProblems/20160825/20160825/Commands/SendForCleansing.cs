namespace _20160825.Commands
{
    using Models.Centers;
    using Models.Animals;
    using System.Collections.Generic;
    using System.Linq;
    public class SendForClenasing : Command
    {
        private string adoptionCenter;
        private string cleansingCenter;
        public SendForClenasing(string adoptionCenter, string cleansingCenter)
        {
            this.adoptionCenter = adoptionCenter;
            this.cleansingCenter = cleansingCenter;
        }
        public override void Execute()
        {
            List<Animal> temp = PawInc.AdoptionCenters.Find(c => c.Name.Equals(this.adoptionCenter)).StoredAnimals.Where(x => x.Cleansed == false).ToList();
            foreach (var animal in temp)
            {
                PawInc.CleansingCenters.Find(c => c.Name.Equals(this.cleansingCenter)).StoredAnimals.Add(animal);
            }
            PawInc.AdoptionCenters.Find(c => c.Name.Equals(this.adoptionCenter)).StoredAnimals.RemoveAll(a => a.Cleansed == false);
        }
    }
}

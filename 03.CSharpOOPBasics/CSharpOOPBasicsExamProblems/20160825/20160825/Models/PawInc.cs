using System.Linq;

namespace _20160825.Models.Centers
{
    using System;
    using Models.Centers;
    using System.Collections.Generic;
    using Animals;
    public static class PawInc
    {
        public static List<AdoptionCenter> AdoptionCenters = new List<AdoptionCenter>();
        public static List<CleansingCenter> CleansingCenters = new List<CleansingCenter>();
        public static List<Animal> Adopted = new List<Animal>();
        public static List<Animal> Cleansed = new List<Animal>();

        public static void Result()
        {
            Console.WriteLine("Paw Incorporative Regular Statistics");
            Console.WriteLine("Adoption Centers: {0}", AdoptionCenters.Count);
            Console.WriteLine("Cleansing Centers: {0}", CleansingCenters.Count);
            List<string> adoptedAnimals = PawInc.Adopted.Select(a => a.Name).OrderBy(a => a).ToList();
            if (adoptedAnimals.Count == 0)
            {
                Console.WriteLine("Adopted Animals: None");
            }
            else
            {
                Console.WriteLine("Adopted Animals: {0}", string.Join(", ", adoptedAnimals));
            }
            List<string> cleansedAnimals = PawInc.Cleansed.Select(a => a.Name).OrderBy(a => a).ToList();
            if (cleansedAnimals.Count == 0)
            {
                Console.WriteLine("Cleansed Animals: None");
            }
            else
            {
                Console.WriteLine("Cleansed Animals: {0}", string.Join(", ", cleansedAnimals));
            }

            List<Animal> awaitingAdoption = PawInc.AdoptionCenters.SelectMany(x=>x.StoredAnimals.Where(a=>a.Cleansed==true)).ToList();
            Console.WriteLine("Animals Awaiting Adoption: {0}", awaitingAdoption.Count);
            List<Animal> awaitingCleansing = PawInc.CleansingCenters.SelectMany(x => x.StoredAnimals.Where(a => a.Cleansed == false)).ToList();
            Console.WriteLine("Animals Awaiting Cleansing: {0}", awaitingCleansing.Count);
        }
    }
}

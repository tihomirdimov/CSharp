using System;
using System.Collections.Generic;
using System.Linq;

namespace Minedraft.Core.Controllers
{
    public class HarvesterController : IHarvesterController
    {
        private List<IHarvester> harvesters;
        private IEnergyRepository energyRepository;
        private IOreRepository oreRepository;
        private IHarvesterFactory factory;

        public HarvesterController(IEnergyRepository energyRepository, IOreRepository oreRepository)
        {
            this.energyRepository = energyRepository;
            this.oreRepository = oreRepository;
            this.harvesters = new List<IHarvester>();
            this.factory = new HarvesterFactory();
        }

        public double OreProduced { get; }

        public string Register(IList<string> args)
        {
            var harvester = this.factory.GenerateHarvester(args);
            this.harvesters.Add(harvester);
            return string.Format(Constants.SuccessfullRegistration,
                harvester.GetType().Name);
        }

        public string Produce()
        {
            double oreProduced = this.harvesters.Where(h => h.Durability >= 0).Sum(h => h.OreOutput);
            this.oreRepository.StoreOre(oreProduced);
            List<IProvider> reminder = new List<IProvider>();

            foreach (var harvester in this.harvesters)
            {
                if (harvester.Durability <= 0)
                {
                    harvesters.Remove(harvester);
                }
            }

            return string.Format(Constants.EnergyOutputToday, oreProduced);
        }

        public string ChangeMode(string mode)
        {
            throw new NotImplementedException();
        }
    }
}
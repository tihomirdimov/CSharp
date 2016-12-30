using BoatRacingSimulator.Models;
using BoatRacingSimulator.Models.Boats;

namespace BoatRacingSimulator.Database
{
    using BoatRacingSimulator.Interfaces;

    public class BoatSimulatorDatabase
    {
        public BoatSimulatorDatabase()
        {
            this.Boats = new Repository<IBoat>();
            this.Engines = new Repository<IModelable>();
        }

        public IRepository<IBoat> Boats { get; private set; }

        public IRepository<IModelable> Engines { get; private set; }
    }
}

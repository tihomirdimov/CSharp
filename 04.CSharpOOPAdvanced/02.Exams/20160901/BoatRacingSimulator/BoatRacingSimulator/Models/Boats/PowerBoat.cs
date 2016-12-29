

namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using BoatRacingSimulator.Interfaces;

    public class PowerBoat : Boat
    {
        private IBoatEngine firstEngine;
        private IBoatEngine secondEngine;

        public PowerBoat(string model, int weight, IBoatEngine firstEngine, IBoatEngine secondEngine) : base(model, weight)
        {
            this.FirstEngine = firstEngine;
            this.SecondEngine = secondEngine;
        }

        public object JetEngines { get; private set; }

        internal IBoatEngine FirstEngine
        {
            get { return firstEngine; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        internal IBoatEngine SecondEngine
        {
            get { return secondEngine; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.FirstEngine.Output + this.SecondEngine.Output - this.Weight + (race.OceanCurrentSpeed / 5d);
            return speed;
        }
    }
}





using BoatRacingSimulator.Interfaces;
using BoatRacingSimulator.Utility;

namespace BoatRacingSimulator.Models.Boats
{
    using System;
    public class YachtBoat : Boat, IEngine
    {
        IBoatEngine engine;
        private int cargoWeight;

        public YachtBoat(string model, int weight, int cargoWeight,  IBoatEngine engine) : base(model, weight)
        {
            this.Engine = engine;
            this.CargoWeight = cargoWeight;
        }

        internal IBoatEngine Engine
        {
            get { return engine; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.engine = value;
            }
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.Engine.Output - (this.Weight + this.CargoWeight) + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}

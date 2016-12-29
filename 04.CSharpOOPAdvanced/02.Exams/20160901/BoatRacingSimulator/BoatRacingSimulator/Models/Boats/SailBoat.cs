﻿using BoatRacingSimulator.Interfaces;

namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using BoatRacingSimulator.Utility;

    class SailBoat : Boat
    {
        private int sailEfficiency;

        public SailBoat(string model, int weight, int sailEfficiency) : base(model, weight)
        {
            this.SailEfficiency = sailEfficiency;
        }

        public int SailEfficiency
        {
            get
            {
                return this.sailEfficiency;
            }

            private set
            {
                Validator.ValidateRange(value);
                this.sailEfficiency = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = (race.WindSpeed * (this.SailEfficiency / 100d)) - this.Weight + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}

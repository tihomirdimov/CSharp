using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRacingSimulator.Models.BoatEngines
{
    class BoatSterndriveEngine : BoatEngine
    {
        private const int Multiplier = 7;

        public BoatSterndriveEngine(string model, int horsepower, int displacement) : base(model, horsepower, displacement)
        {
        }

        public override int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * Multiplier) + this.Displacement;
                return this.CachedOutput;
            }
        }
    }
}

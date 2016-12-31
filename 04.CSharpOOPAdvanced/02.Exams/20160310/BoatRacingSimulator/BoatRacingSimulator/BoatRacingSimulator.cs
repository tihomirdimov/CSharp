using System;
using System.Collections.Generic;
using System.Linq;

namespace BoatRacingSimulator
{
    using global::BoatRacingSimulator.Core;

    public class BoatRacingSimulator
    {
        public static void Main()
        {
            var engine = new CommandEngine();
            engine.Run();
        }
    }
}

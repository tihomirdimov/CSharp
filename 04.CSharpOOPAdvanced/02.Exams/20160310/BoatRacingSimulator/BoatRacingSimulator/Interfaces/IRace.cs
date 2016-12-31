﻿using BoatRacingSimulator.Models.Boats;

namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;
    using global::BoatRacingSimulator.Models;

    public interface IRace
    {
        int Distance { get; }

        int WindSpeed { get; }

        int OceanCurrentSpeed { get; }

        bool AllowsMotorboats { get; }

        void AddParticipant(IBoat boat);

        IList<IBoat> GetParticipants();
    }
}

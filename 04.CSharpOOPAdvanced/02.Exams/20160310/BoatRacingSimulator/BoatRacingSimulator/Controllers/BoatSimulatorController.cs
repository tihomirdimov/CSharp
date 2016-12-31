using System.Diagnostics;

namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using global::BoatRacingSimulator.Database;
    using global::BoatRacingSimulator.Enumerations;
    using global::BoatRacingSimulator.Exceptions;
    using global::BoatRacingSimulator.Interfaces;
    using global::BoatRacingSimulator.Models;
    using global::BoatRacingSimulator.Utility;
    using global::BoatRacingSimulator.Models.Boats;
    using Models.BoatEngines;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController() : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IModelable engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new BoatJetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new BoatSterndriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.Engines.Add(engine);
            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
                model,
                horsepower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);
            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);
            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            IBoatEngine firstEngine = this.Database.Engines.GetItem(firstEngineModel) as IBoatEngine;
            IBoatEngine secondEngine = this.Database.Engines.GetItem(secondEngineModel) as IBoatEngine;
            IBoat boat = new PowerBoat(model, weight, firstEngine, secondEngine);
            this.Database.Boats.Add(boat);
            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            IBoatEngine engine = this.Database.Engines.GetItem(engineModel) as IBoatEngine;
            IBoat boat = new YachtBoat(model, weight, cargoWeight, engine);
            this.Database.Boats.Add(boat);
            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;
            return
                string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance, windSpeed, oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            IBoat boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();
            if (!this.CurrentRace.AllowsMotorboats && boat is IEngine)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }
            this.CurrentRace.AddParticipant(boat);
            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var participantsWithPositiveTimes = this.CurrentRace.GetParticipants()
                .Where(p => this.CurrentRace.Distance / p.CalculateRaceSpeed(this.CurrentRace) > 0)
                .OrderBy(p => this.CurrentRace.Distance / p.CalculateRaceSpeed(this.CurrentRace)).ToList();
            var participantsWithNegativeTimes = this.CurrentRace.GetParticipants()
                .Where(p => this.CurrentRace.Distance / p.CalculateRaceSpeed(this.CurrentRace) <= 0)
                .OrderByDescending(p => this.CurrentRace.Distance / p.CalculateRaceSpeed(this.CurrentRace)).ToList();

            var finalTimes = new List<IBoat>();

            foreach (var participant in participantsWithPositiveTimes)
            {
                finalTimes.Add(participant);
            }

            foreach (var participant in participantsWithNegativeTimes)
            {
                finalTimes.Add(participant);
            }

            var result = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var currentBoat = finalTimes[i];
                var currentTime = this.CurrentRace.Distance / currentBoat.CalculateRaceSpeed(this.CurrentRace);
                string place = "";
                switch (i)
                {
                    case 0:
                        place = "First";
                        break;
                    case 1:
                        place = "Second";
                        break;
                    case 2:
                        place = "Third";
                        break;
                }
                result.AppendLine(string.Format("{3} place: {0} Model: {1} Time: {2}",
                    currentBoat.GetType().Name,
                    currentBoat.Model,
                    currentTime < 0 ? "Did not finish!" : Math.Round(currentTime, 2) + " sec",
                    place));
            }
            this.CurrentRace = null;
            return result.ToString();
        }

        public string GetStatistic()
        {
            //TODO Bonus Task Implement me
            throw new NotImplementedException();
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}

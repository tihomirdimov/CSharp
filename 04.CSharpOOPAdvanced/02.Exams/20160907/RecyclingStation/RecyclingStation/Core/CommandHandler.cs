using RecyclingStation.Models;

namespace RecyclingStation.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class CommandHandler
    {
        public CommandHandler()
        {
            this.StrategyHolder = new StrategyHolder();
        }

        internal StrategyHolder StrategyHolder { get; }

        public IProcessingData Process(string input)
        {
            StrategyHolder.InitializeStrategies();
            IGarbageProcessor garbageProcessor = new GarbageProcessor(StrategyHolder);
            string[] tokens = input.Substring(15).Split('|');
            string name = tokens[0];
            double weight = Double.Parse(tokens[1], CultureInfo.InvariantCulture);
            double volumePerKg = Double.Parse(tokens[2], CultureInfo.InvariantCulture);
            string type = tokens[3];
            string garbageTypeName = type + "Garbage";
            Type garbageType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(s => s.Namespace == "RecyclingStation.Models.Garbage" && !s.IsAbstract)
                .FirstOrDefault(x => x.Name == garbageTypeName);
            if (garbageType == null)
            {
                throw new ArgumentException("Unsupported garbage type passed!");
            }
            object[] parameters = new object[3];
            parameters[0] = name;
            parameters[1] = weight;
            parameters[2] = volumePerKg;
            IWaste garbage = (IWaste)Activator.CreateInstance(garbageType, parameters);
            try
            {
                IProcessingData processedWaste = garbageProcessor.ProcessWaste(garbage);
                Console.WriteLine("{0:F2} kg of {1} successfully processed!", garbage.Weight, garbage.Name);
                return processedWaste;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                return new ProcessingData(0, 0);
            }
        }
    }
}
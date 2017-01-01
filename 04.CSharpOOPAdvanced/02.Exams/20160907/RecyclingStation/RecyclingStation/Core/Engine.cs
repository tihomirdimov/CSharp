
using System.Linq;
using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Core
{
    using System;
    using System.Globalization;
    using System.Reflection;

    class Engine
    {
        private CommandHandler commandHandler;

        public Engine()
        {
        }

        public CommandHandler CommandHandler { get; }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "TimeToRecycle")
            {
                if (input.StartsWith("ProcessGarbage"))
                {
                    string[] tokens = input.Substring(15).Split('|');
                    string name = tokens[0];
                    double weight = Double.Parse(tokens[1], CultureInfo.InvariantCulture);
                    double volumePerKg = Double.Parse(tokens[2], CultureInfo.InvariantCulture);
                    string type = tokens[3];
                    var currentClass = Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.Namespace == "RecyclingStation.Models.Garbage")
                        .ToList();
                    foreach (var current in currentClass)
                    {
                        var attr = current.GetCustomAttributes(typeof(DisposableAttribute), false);
                        foreach (var att in attr)
                        {
                            string attname = att.GetType().Name;
                            string currentType = type + "Attribute";
                            if (attname.Equals(currentType))
                            {
                                Console.WriteLine(current.Name);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine(input);
                }
                input = Console.ReadLine();
            }
        }
    }
}

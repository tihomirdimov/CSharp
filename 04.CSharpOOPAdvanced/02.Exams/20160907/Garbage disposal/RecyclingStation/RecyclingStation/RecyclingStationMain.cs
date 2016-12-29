namespace RecyclingStation
{
    using System;
    using RecyclingStation.WasteDisposal.Models;
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Models.Garbage;
    using RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies;
    using System.Globalization;
    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            RecyclingStation recyclingStation = new RecyclingStation();
            string input = Console.ReadLine();
            while (!input.Equals("TimeToRecycle"))
            {
                string[] command = input.Split(' ');
                if (command[0].Equals("ProcessGarbage"))
                {
                    string[] garbageData = command[1].Split('|');
                    string name = garbageData[0];
                    double weight = double.Parse(garbageData[1], CultureInfo.InvariantCulture);
                    double volumePerKg = double.Parse(garbageData[2], CultureInfo.InvariantCulture);
                    string type = garbageData[3];
                    recyclingStation.SetBalance(DisposeGarbage(type, name, weight, volumePerKg));
                    Console.WriteLine("{0:F2} kg of {1} successfully processed!", weight, name);
                }
                else
                {
                    recyclingStation.GetStatus();
                }
                input = Console.ReadLine();
            }
        }
        public static IProcessingData DisposeGarbage(string type, string name, double weight, double volume)
        {
            switch (type)
            {
                case "Recyclable":
                    RecyclableGarbage recyclable = new RecyclableGarbage(name, volume, weight);
                    RecyclableGarbageDisposalStrategy recyclableStrategy = new RecyclableGarbageDisposalStrategy();
                    IProcessingData result = recyclableStrategy.ProcessGarbage(recyclable);
                    return result;
                case "Burnable":
                    BurnableGarbage burnable = new BurnableGarbage(name, volume, weight);
                    BurnableGarbageDisposalStrategy burnableStrategy = new BurnableGarbageDisposalStrategy();
                    IProcessingData result2 = burnableStrategy.ProcessGarbage(burnable);
                    return result2;
                case "Storable":
                    StorableGarbage storable = new StorableGarbage(name, volume, weight);
                    StorableGarbageDisposalStrategy storableStrategy = new StorableGarbageDisposalStrategy();
                    IProcessingData result3 = storableStrategy.ProcessGarbage(storable);
                    return result3;
                default:
                    return new ProcessingData(0,0);
            }
        }
    }
}

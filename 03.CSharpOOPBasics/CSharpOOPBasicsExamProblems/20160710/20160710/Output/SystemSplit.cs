namespace _20160710.Output
{
    using System;
    using System.Linq;
    using _20160710.Models;
    public static class SystemSplit
    {
        public static void Run()
        {
            foreach (var item in TheSystem.Components.Where(h => h.Type.Equals("Power")))
            {
                Console.WriteLine("Hardware Component - {0}", item.Name);
                Console.WriteLine("Express Software Components - {0}", item.Software.Count(h => h.Type.Equals("Express")));
                Console.WriteLine("Light Software Components - {0}", item.Software.Count(h => h.Type.Equals("Light")));
                Console.WriteLine("Memory Usage: {0} / {1}", item.Software.Sum(s => s.MemoryConsumption),
                    item.MaximumMemory);
                Console.WriteLine("Capacity Usage: {0} / {1}", item.Software.Sum(s => s.CapacityConsumption),
                    item.MaximumCapacity);
                Console.WriteLine("Type: {0}", item.Type);
                if (item.Software.Count == 0)
                {
                    Console.WriteLine("Software Components: None");
                }
                else
                {
                    Console.WriteLine("Software Components: {0}", string.Join(", ", item.Software.Select(s => s.Name).ToArray()));
                }

            }
            foreach (var item in TheSystem.Components.Where(h => h.Type.Equals("Heavy")))
            {
                Console.WriteLine("Hardware Component - {0}", item.Name);
                Console.WriteLine("Express Software Components - {0}", item.Software.Count(h => h.Type.Equals("Express")));
                Console.WriteLine("Light Software Components - {0}", item.Software.Count(h => h.Type.Equals("Light")));
                Console.WriteLine("Memory Usage: {0} / {1}", item.Software.Sum(s => s.MemoryConsumption),
                    item.MaximumMemory);
                Console.WriteLine("Capacity Usage: {0} / {1}", item.Software.Sum(s => s.CapacityConsumption),
                    item.MaximumCapacity);
                Console.WriteLine("Type: {0}", item.Type);
                if (item.Software.Count == 0)
                {
                    Console.WriteLine("Software Components: None");
                }
                else
                {
                    Console.WriteLine("Software Components: {0}", string.Join(", ", item.Software.Select(s=>s.Name).ToArray()));
                }
            }
        }
    }
}
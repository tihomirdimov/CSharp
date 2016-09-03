namespace _20160710.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class TheSystem
    {
        public static List<Hardware> Components = new List<Hardware>();
        public static void Analyze()
        {
            Console.WriteLine("System Analysis");
            Console.WriteLine("Hardware Components: {0}", TheSystem.Components.Count());
            Console.WriteLine("Software Components: {0}", TheSystem.Components.Sum(h => h.Software.Count));
            Console.WriteLine("Total Operational Memory: {0} / {1}",
                TheSystem.Components.Sum(h => h.Software.Sum(s => s.MemoryConsumption)),
                TheSystem.Components.Sum(h => h.MaximumMemory));
            Console.WriteLine("Total Capacity Taken: {0} / {1}",
                TheSystem.Components.Sum(h => h.Software.Sum(s => s.CapacityConsumption)),
                TheSystem.Components.Sum(h => h.MaximumCapacity));
        }
        public static void SystemSplit()
        {
            foreach (var item in TheSystem.Components.Where(h => h.Type.Equals("Power")))
            {
                Console.WriteLine("Hardware Component – {0}", item.Name);
                Console.WriteLine("Express Software Components: {0}", item.Software.Count(h => h.Type.Equals("Express")));
                Console.WriteLine("Light Software Components: {0}", item.Software.Count(h => h.Type.Equals("Light")));
                Console.WriteLine("Memory Usage: {0} / {1}", item.Software.Sum(s => s.MemoryConsumption), item.MaximumMemory);
                Console.WriteLine("Capacity Usage: {0} / {1}", item.Software.Sum(s => s.CapacityConsumption), item.MaximumCapacity);
                Console.WriteLine("Type: {0}", item.Type);
                if (item.Software.Count == 0)
                {
                    Console.WriteLine("Software Components: None");
                }
                else
                {
                    Console.WriteLine("Software Components: ", string.Join(", ", item.Software));
                }

            }
            foreach (var item in TheSystem.Components.Where(h => h.Type.Equals("Heavy")))
            {
                Console.WriteLine("Hardware Component – {0}", item.Name);
                Console.WriteLine("Express Software Components: {0}", item.Software.Count(h => h.Type.Equals("Express")));
                Console.WriteLine("Light Software Components: {0}", item.Software.Count(h => h.Type.Equals("Light")));
                Console.WriteLine("Memory Usage: {0} / {1}", item.Software.Sum(s => s.MemoryConsumption), item.MaximumMemory);
                Console.WriteLine("Capacity Usage: {0} / {1}", item.Software.Sum(s => s.CapacityConsumption), item.MaximumCapacity);
                Console.WriteLine("Type: {0}", item.Type);
                if (item.Software.Count == 0)
                {
                    Console.WriteLine("Software Components: None");
                }
                else
                {
                    Console.WriteLine("Software Components: ", string.Join(", ", item.Software));
                }
            }
        }
    }
}
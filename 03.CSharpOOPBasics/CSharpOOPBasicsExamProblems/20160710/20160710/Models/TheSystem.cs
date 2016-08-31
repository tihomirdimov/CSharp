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
            Console.WriteLine("Split");
        }
    }
}
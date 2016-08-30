namespace _20160710.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class TheSystem
    {
        public static List<Hardware> Components = new List<Hardware>();
        public static void SystemSplit()
        {
            Console.WriteLine("System Analysis");
            Console.WriteLine("Hardware Components: {0}", TheSystem.Components.Count());
            foreach (var component in TheSystem.Components)
            {
                Console.WriteLine(component.Name);
            }
        }
    }
}
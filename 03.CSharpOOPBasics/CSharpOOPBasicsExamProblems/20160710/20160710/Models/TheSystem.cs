using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160710.Models
{
    public static class TheSystem
    {
        public static List<Component> Components { get; set; }
        public static void SystemSplit()
        {
            Console.WriteLine("System Split");
        }
    }
}

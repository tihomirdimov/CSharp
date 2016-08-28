using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160710.Models
{
    public class Hardware : Component
    {
        private static List<string> SoftwareIcluded;

        public Hardware(string name, string type, int capacity, int memory)
            : base(name, type, capacity, memory)
        {
        }
        public override int Capacity
        {
            get { return Capacity; }
            set
            {
                if (Type.Equals("Power"))
                {
                    Capacity += (int)Math.Floor(value * 0.25);
                }
                else if (Type.Equals("Heavy"))
                {
                    Capacity += Capacity * 2;
                }
            }
        }

        public List<string> SoftwareIncluded
        {
            get;
            set;
        }

        public override int Memory
        {
            get { return Memory; }
            set
            {
                if (Type.Equals("Power"))
                {
                    Memory += (int)Math.Floor(value * 1.75);
                }
                else if (Type.Equals("Heavy"))
                {
                    Memory += (int)Math.Floor(value * 0.25);
                }
            }
        }

        public static List<string> GetSoftware()
        {
            return SoftwareIcluded;
        }

        public static void AddSoftware(string software)
        {

        }

        public override int GetCapacity()
        {
            return Capacity;
        }
        public override int GetMemory()
        {
            return Memory;
        }
    }
}
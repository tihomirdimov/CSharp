using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160710.Models
{
    class Software : Component
    {
        public Software(string name, string type, int capacity, int memory) : base(name, type, capacity, memory)
        {
        }
        public override int GetCapacity()
        {
            if (Type.Equals("Light"))
            {
                Capacity = (int)Math.Floor((double)Capacity * 1.5);
                return Capacity;
            }
            else
            {
                return 0;
            }
        }
        public override int GetMemory()
        {
            if (Type.Equals("Light"))
            {
                Memory = (int)Math.Floor((double)Memory * 0.5);
                return Memory;
            }
            else if (Type.Equals("Express"))
            {
                Memory = (int)Math.Floor((double)Memory * 2);
                return Memory;
            }
            else
            {
                return 0;
            }
        }
    }
}

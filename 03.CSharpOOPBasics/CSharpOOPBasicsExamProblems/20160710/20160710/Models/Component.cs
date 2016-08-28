using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160710.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public abstract class Component
    {
        private string name;
        private string type;
        private int capacity;
        private int memory;
        protected Component(string name, string type, int capacity, int memory)
        {
            this.name = name;
            this.type = type;
            this.capacity = capacity;
            this.memory = memory;
        }
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Type
        {
            get { return type; }
            set { this.type = value; }
        }

        public virtual int Capacity
        {
            get { return capacity; }
            set { this.capacity = value; }
        }

        public virtual int Memory
        {
            get { return memory; }
            set { this.memory = value; }
        }
        public abstract int GetCapacity();
        public abstract int GetMemory();
    }
}

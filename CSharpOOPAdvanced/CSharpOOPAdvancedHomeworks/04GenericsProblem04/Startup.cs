using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04GenericsProblem04
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return this.Value.GetType() + ": " + this.value;
        }
    }
    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var boxList = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                boxList.Add(new Box<string>(Console.ReadLine()));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericsProblem03
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return (this.value.GetType() + ": " + this.value);
        }
    }

    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var inputBox = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(inputBox.ToString());
            }
        }
    }
}

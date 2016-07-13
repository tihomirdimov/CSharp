using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02GenericsProblem01
{
    public class Box<T>
    {
        private string v;
        private T value;

        public Box(string v)
        {
            this.v = v;
        }

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return (this.value.GetType() + " : " + this.value);
        }
    }

    class Startup
    {
        static void Main(string[] args)
        {
            var inputBox = new Box<string>(Console.ReadLine());
            Console.WriteLine(inputBox.ToString());
        }
    }
}

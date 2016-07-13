using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02GenericsProblem01
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
            return (this.value.GetType() + " : " + this.value);
        }
    }

    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var inputBox = new Box<string>(input);
            Console.WriteLine(inputBox.ToString());
        }
    }
}

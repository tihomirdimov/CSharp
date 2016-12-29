using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02GenericsProblem06
{
    public class Box<T>
            where T : IComparable
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return this.Value.GetType() + ": " + this.Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var boxList = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                boxList.Add(new Box<string>(input));
            }
            var elementToCompare = new Box<string>(Console.ReadLine());
            Console.WriteLine(CountGreater(boxList, elementToCompare));
        }
        static int CountGreater<T>(List<Box<T>> list, Box<T> elementToCompare)
     where T : IComparable
        {
            return list.Count(e => e.Value.CompareTo(elementToCompare.Value) > 0);
        }
    }
}

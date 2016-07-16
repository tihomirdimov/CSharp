using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02GenericsProblem05
{
    public class Box<T>
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
    class Startup
    {
        static void Main()
        {
            var elements = new List<Box<int>>();
            var numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                elements.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }
            var indexes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Swap(elements, indexes[0], indexes[1]);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }
        static void Swap<T>(List<Box<T>> elements, int firstIndex, int secondIndex)
        {
            Box<T> temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
    }
}


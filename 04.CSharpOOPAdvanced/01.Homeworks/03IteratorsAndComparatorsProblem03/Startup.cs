using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03IteratorsAndComparatorsProblem03
{
    class CustomStack<T> : IEnumerable<T>
    {
        private List<T> stack;
        public CustomStack()
        {
            this.stack = new List<T>();
        }
        public void Push(List<T> items)
        {
            foreach (var item in items)
            {
                this.stack.Add(item);
            }
        }
        public void Pop()
        {
            if (this.stack.Count > 0)
            {
                this.stack.RemoveAt(this.stack.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    class Startup
    {
        static void Main()
        {
            CustomStack<int> collection = new CustomStack<int>();
            string input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                try
                {
                    if (input.StartsWith("Push"))
                    {
                        var line = input.Substring(4).Split(',').Select(int.Parse).ToList();
                        collection.Push(line);
                    }
                    else if (input.StartsWith("Pop"))
                    {
                        collection.Pop();
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex);
                }
                input = Console.ReadLine();
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03IteratorsAndComparatorsProblem01
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private static int index;
        public ListyIterator()
        {
            collection = new List<T>();
            index = 0;
        }

        public void Create(List<T> elements)
        {
            this.collection = new List<T>();
            this.collection.AddRange(elements);
            index = 0;
        }

        public bool Move()
        {
            if (index < collection.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (index == collection.Count - 1)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(collection[index]);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid Operation!");
            }
        }
    }
    class Startup

    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ListyIterator<string> collection = new ListyIterator<string>();
            while (!input.Equals("END"))
            {
                string[] line = input.Split();
                string command = line[0];
                switch (command)
                {
                    case "Create":
                        List<string> givenCollection = new List<string>();
                        for (int i = 1; i < line.Length; i++)
                        {
                            givenCollection.Add(line[i]);
                        }
                        collection.Create(givenCollection);
                        break;
                    case "Move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(collection.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            collection.Print();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
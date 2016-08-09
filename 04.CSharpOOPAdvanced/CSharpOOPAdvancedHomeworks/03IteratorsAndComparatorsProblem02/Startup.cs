using System;
using System.Collections;
using System.Collections.Generic;
namespace _03IteratorsAndComparatorsProblem01
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public string Print()
        {
            try
            {
                return collection[index].ToString();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid Operation!");
            }
        }
        public string PrintAll()
        {
            try
            {
                return string.Join(" ", this.collection);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid Operation!");
            }


        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
                            Console.WriteLine(collection.Print());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            Console.WriteLine(collection.PrintAll());
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
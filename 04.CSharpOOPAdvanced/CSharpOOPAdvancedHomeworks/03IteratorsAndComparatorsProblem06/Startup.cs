using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03IteratorsAndComparatorsProblem06
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; }
        public int Age { get; }
        public override string ToString()
        {
            return this.Name + " " + this.Age;
        }
    }
    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);
            if (result == 0)
            {
                var firstName = x.Name[0].ToString();
                var secondName = y.Name[0].ToString();

                result = string.Compare(firstName, secondName, StringComparison.OrdinalIgnoreCase);
            }
            return result;
        }
    }
    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
    class Startup
    {
        static void Main(string[] args)
        {
            var sortedByName = new SortedSet<Person>(new NameComparer());
            var sortedByAge = new SortedSet<Person>(new AgeComparer());
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                sortedByName.Add(person);
                sortedByAge.Add(person);
            }
            foreach (var person in sortedByName)
            {
                Console.WriteLine(person);
            }
            foreach (var person in sortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
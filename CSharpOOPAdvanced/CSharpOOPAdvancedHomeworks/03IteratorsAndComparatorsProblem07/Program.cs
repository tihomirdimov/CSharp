using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03IteratorsAndComparatorsProblem07
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; }
        public int Age { get; }
        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }
            if (this.CompareTo(other) == 0)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = this.Age;
            hash = hash * 486187739 + this.Name.GetHashCode();
            return hash;
        }
        public int CompareTo(Person other)
        {
            int result = string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
    class Program
    {
        static void Main()
        {
            var sorted = new SortedSet<Person>();
            var hashed = new HashSet<Person>();
            var numberOflines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOflines; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ');
                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);
                var person = new Person(personName, personAge);
                sorted.Add(person);
                hashed.Add(person);
            }
            Console.WriteLine(sorted.Count);
            Console.WriteLine(hashed.Count);
        }
    }
}

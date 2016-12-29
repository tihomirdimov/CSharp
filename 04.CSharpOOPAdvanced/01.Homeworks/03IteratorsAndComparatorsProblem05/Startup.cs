using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03IteratorsAndComparatorsProblem05
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;
        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.name.Equals(other.name) && this.age == other.age && this.town.Equals(other.town))
            {
                return 1;
            }
            return 0;
        }
        public string FindDuplicate(List<Person> people)
        {
            Person current = new Person(this.name, this.age, this.town);
            int duplicates = 0;
            foreach (var personToCompare in people)
            {
                if (current.CompareTo(personToCompare) == 1)
                {
                    duplicates++;
                }
            }
            if (duplicates == 1)
            {
                return "No matches";
            }
            return duplicates + " " + (people.Count - duplicates) + " " + people.Count;
        }
    }
    class Startup
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            var input = Console.ReadLine().Split(' ');
            while (!input[0].Equals("END"))
            {
                var personName = input[0];
                var personAge = int.Parse(input[1]);
                var personTown = input[2];
                var person = new Person(personName, personAge, personTown);
                people.Add(person);
                input = Console.ReadLine().Split(' ');
            }
            int index = int.Parse(Console.ReadLine());
            if (index > people.Count - 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(people[index].FindDuplicate(people));
            }

        }
    }
}

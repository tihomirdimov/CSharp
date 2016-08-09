using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02MethodsProblem02
{
    class Person
    {
        public string name;
        public int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    class Family
    {
        private List<Person> familyMembers;
        public Family()
        {
            this.familyMembers = new List<Person>();
        }
        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }
        public string GetOldestMember()
        {
            var oldest = familyMembers.OrderByDescending(x => x.age).FirstOrDefault();
            return oldest.name + " " + oldest.age;
        }
    }

    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Regex.Split(Console.ReadLine(), @"\s+");
                Person person = new Person(input[0], int.Parse(input[1]));
                family.AddMember(person);
            }
            Console.WriteLine(family.GetOldestMember());
        }
    }
}

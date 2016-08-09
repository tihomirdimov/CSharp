using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Person
{
    public int age;
    public string name;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
class OpinionPoll
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] personInfo = input.Split(' ');
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            people.Add(new Person(name, age));
        }
        var sorted = people.OrderBy(o => o.name).Where(o => o.age > 30);
        foreach (Person sort in sorted)
        {
            Console.WriteLine(@"{0} - {1}", sort.name, sort.age);
        }

    }
}
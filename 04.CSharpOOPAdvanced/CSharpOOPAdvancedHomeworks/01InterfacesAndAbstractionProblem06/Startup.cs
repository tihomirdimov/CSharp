using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01InterfacesAndAbstractionProblem06
{
    public interface IIdentifiable
    {
        string Id { get; }
    }

    public interface IBirthday
    {
        string Birthday { get; }
    }

    public class Citizen : IIdentifiable, IBirthday
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthday { get; }
    }

    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; }
        public string Id { get; }
    }

    public class Pet : IBirthday
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; }
        public string Birthday { get; }
    }

    class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthday> inhabitantsWithBirthday = new List<IBirthday>();
            while (!input.Equals("End"))
            {
                string[] inhabitant = input.Split(' ');
                if (inhabitant[0].Equals("Citizen"))
                {
                    inhabitantsWithBirthday.Add(new Citizen(inhabitant[1], int.Parse(inhabitant[2]), inhabitant[3], inhabitant[4]));
                }
                else if (inhabitant[0].Equals("Pet"))
                {
                    inhabitantsWithBirthday.Add(new Pet(inhabitant[1], inhabitant[2]));
                }
                input = Console.ReadLine();
            }
            string year = Console.ReadLine();
            foreach (var inhabitant in inhabitantsWithBirthday)
            {
                if (inhabitant.Birthday.EndsWith(year))
                {
                    Console.WriteLine(inhabitant.Birthday);
                }
            }
        }
    }
}

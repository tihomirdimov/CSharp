using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01InterfacesAndAbstractionProblem05
{
    public interface IIdentifiable
    {
        string Id { get; }
    }

    public class Citizen:IIdentifiable
    {
        public Citizen(string name, int age, string id )
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
    }

    public class Robot:IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; }
        public string Id { get; }
    }

    class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentifiable> inhabitants = new List<IIdentifiable>();
            while (!input.Equals("End"))
            {
                string[] inhabitant = input.Split(' ');
                if (inhabitant.Count() == 3)
                {
                    inhabitants.Add(new Citizen(inhabitant[0],int.Parse(inhabitant[1]),inhabitant[2]));
                }
                else if (inhabitant.Count() == 2)
                {
                    inhabitants.Add(new Robot(inhabitant[0], inhabitant[1]));
                }
                input = Console.ReadLine();
            }
            string key = Console.ReadLine();
            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.Id.EndsWith(key))
                {
                    Console.WriteLine(inhabitant.Id);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01InterfacesAndAbstractionProblem07
{
    public interface IBuyer
    {
        int Food { get; set; }
        void BuyFood();
    }

    public abstract class Inhabitant
    {
        protected Inhabitant(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Citizen : Inhabitant, IBuyer
    {
        public Citizen(string name, int age, string id, string birthday) : base(name, age)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Food = 0;
        }
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }

    public class Rebel : Inhabitant, IBuyer
    {
        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }

    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            for (int i = 0; i < n; i++)
            {
                string[] inhabitant = Console.ReadLine().Split(' ');
                if (inhabitant.Count() == 4)
                {
                    citizens.Add(new Citizen(inhabitant[0], int.Parse(inhabitant[1]), inhabitant[2], inhabitant[3]));
                }
                else if (inhabitant.Count() == 3)
                {
                    rebels.Add(new Rebel(inhabitant[0], int.Parse(inhabitant[1]), inhabitant[2]));
                }
            }
            string input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                var matchingCitizen = citizens.FirstOrDefault(i => i.Name.Equals(input));
                var matchingRebel = rebels.FirstOrDefault(i => i.Name.Equals(input));
                if (matchingCitizen != null)
                {
                    citizens.First(i => i.Name.Equals(input)).BuyFood();
                }
                else if (matchingRebel != null)
                {
                    rebels.First(i => i.Name.Equals(input)).BuyFood();
                }
                input = Console.ReadLine();
            }
            int food = 0;
            foreach (var citizen in citizens)
            {
                food += citizen.Food;
            }
            foreach (var rebel in rebels)
            {
                food += rebel.Food;
            }
            Console.WriteLine(food);
        }
    }
}
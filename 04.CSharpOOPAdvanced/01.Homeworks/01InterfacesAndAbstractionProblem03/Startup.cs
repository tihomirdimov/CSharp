using System;

namespace _01InterfacesAndAbstractionProblem03
{
    interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string Brake();

        string Gas();
    }

    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            Model = "488-Spider";
            Driver = driver;
        }

        public string Model { get; set; }
        public string Driver { get; set; }

        public string Brake()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return this.Model + "/" + this.Brake() + "/" + this.Gas() + "/" + this.Driver;
        }

    }

    class Startup
    {
        static void Main(string[] args)
        {
            var ferrari = new Ferrari(Console.ReadLine());
            Console.WriteLine(ferrari.ToString());
            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

        }
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01DefiningClassesProblem07
{
    class Car
    {
        public string model;
        public Engine engine;
        public int weight = 0;
        public string color = "n/a";

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.weight = weight;
            this.color = "n/a";
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.weight = 0;
            this.color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.weight = weight;
            this.color = color;
        }
        public override string ToString()
        {
            string weight;
            if (this.weight == 0)
            {
                weight = "n/a";
            }
            else
            {
                weight = this.weight.ToString();
            }
            string result = this.model + ":" + Environment.NewLine +
                "  " + this.engine.ToString() + Environment.NewLine +
                "  Weight: " + weight + Environment.NewLine +
                "  Color: "+ this.color;
            return result;
        }
    }

    class Engine
    {
        public string model;
        public int power;
        public int displacement = 0;
        public string efficiency = "n/a";

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.displacement = 0;
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
        public override string ToString()
        {
            string displacement;
            if (this.displacement == 0)
            {
                displacement = "n/a";
            }
            else
            {
                displacement = this.displacement.ToString();
            }
            string result = this.model + ":" + Environment.NewLine
                + "  Power: "+ this.power + Environment.NewLine
                + "    Displacement: " + displacement + Environment.NewLine
                + "    Efficiency: " + this.efficiency;
            return result;
        }
    }

    class CarSalesman
    {
        public static List<Car> cars = new List<Car>();
        public static List<Engine> engines = new List<Engine>();

        static void Main(string[] args)
        {
            int enginesNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesNum; i++)
            {
                int displacement;
                string[] input = Regex.Split(Console.ReadLine(), @"\s+");
                if (input.Length == 2)
                {
                    engines.Add(new Engine(input[0], int.Parse(input[1])));
                }
                else if (input.Length == 3 && int.TryParse(input[2], out displacement))
                {
                    engines.Add(new Engine(input[0], int.Parse(input[1]), displacement));
                }
                else if (input.Length == 3)
                {
                    engines.Add(new Engine(input[0], int.Parse(input[1]), input[2]));
                }
                else
                {
                    engines.Add(new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]));
                }
            }
            int carsNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNum; i++)
            {
                string[] input = Regex.Split(Console.ReadLine(), @"\s+");
                int weight;
                if (input.Length == 2)
                {
                    cars.Add(new Car(input[0], GetEngineData(input[1])));
                }
                else if (input.Length == 3 && int.TryParse(input[2], out weight))
                {
                    cars.Add(new Car(input[0], GetEngineData(input[1]), weight));
                }
                else if (input.Length == 3)
                {
                    cars.Add(new Car(input[0], GetEngineData(input[1]), input[2]));
                }
                else
                {
                    cars.Add(new Car(input[0], GetEngineData(input[1]), int.Parse(input[2]), input[3]));
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());

            }
        }
        public static Engine GetEngineData(string model)
        {
            return engines.Find(x => x.model.Equals(model));
        }
    }
}
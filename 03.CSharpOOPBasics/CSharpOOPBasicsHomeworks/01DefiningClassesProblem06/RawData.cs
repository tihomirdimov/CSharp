using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01DefiningClassesProblem06
{
    class Car
    {
        public string model;
        public Engine carEngine;
        public Cargo carCargo;
        public List<Tire> carTires;
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.model = model;
            this.carEngine = engine;
            this.carCargo = cargo;
            this.carTires = tires;
        }
        public override string ToString()
        {
            return this.model;
        }
    }

    class Engine
    {
        int engineSpeed;
        public int enginePower;
        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }
    }

    class Cargo
    {
        int cargoWeight;
        public string cargoType;
        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
    }

    class Tire
    {
        public double pressure;
        int age;
        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }
    }

    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < carNum; i++)
            {
                string[] carData = Regex.Split(Console.ReadLine(), @"\s+");
                string model = carData[0];
                Engine engine = new Engine(int.Parse(carData[1]),int.Parse(carData[2]));
                Cargo cargo = new Cargo(int.Parse(carData[3]), carData[4]);
                List<Tire> tires = new List<Tire>();
                tires.Add(new Tire(double.Parse(carData[5], CultureInfo.InvariantCulture), int.Parse(carData[6])));
                tires.Add(new Tire(double.Parse(carData[7], CultureInfo.InvariantCulture), int.Parse(carData[8])));
                tires.Add(new Tire(double.Parse(carData[9], CultureInfo.InvariantCulture), int.Parse(carData[10])));
                tires.Add(new Tire(double.Parse(carData[11], CultureInfo.InvariantCulture), int.Parse(carData[12])));
                cars.Add(new Car(model,engine,cargo,tires));
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.carCargo.cargoType == "fragile" && CheckPressure(car.carTires))
                    {
                        Console.WriteLine(car.model);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                foreach (var car in cars)
                {
                    if (car.carCargo.cargoType == "flamable" && car.carEngine.enginePower > 250)
                    {
                        Console.WriteLine(car.model);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public static bool CheckPressure(List<Tire> tires)
        {
            bool result = false;
            foreach (var tire in tires)
            {
                if (tire.pressure < 1)
                {
                    result = true;
                }
                else
                {
                    continue;
                }
            }
            return result;
        }
    }
}

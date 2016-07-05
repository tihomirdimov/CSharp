using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _06PolymorphismProblem01
{
    class Vehicle
    {
        private string name;
        private double fuelQuantity;
        private double fuelConsumption;
        public Vehicle(string name, double fuelQuantity, double fuelConsumption)
        {
            this.name = name;
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                fuelConsumption = value;
            }
        }
        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
            }
        }
        public virtual string Drive(double distanceToDrive)
        {
            if (distanceToDrive * this.fuelConsumption <= fuelQuantity)
            {
                return String.Format("{0} travelled {1:0.00} km", this.name, distanceToDrive);
            }
            else
            {
                return String.Format("{0} needs refueling", this.name, distanceToDrive);
            }
        }
        public virtual void Refuel(double quantityToRefuel)
        {
            this.fuelQuantity += quantityToRefuel;
        }
        public virtual string GetInfo()
        {
            return String.Format("{0}: {1:0.00}", this.name, this.fuelQuantity);
        }
    }
    class Car : Vehicle
    {
        private double additionalConsumption;
        public Car(string name, double fuelQuantity, double fuelConsumption) : base(name, fuelQuantity, fuelConsumption)
        {
            this.additionalConsumption = 0.9;
        }

        public override string Drive(double distanceToDrive)
        {
            if (distanceToDrive * (this.FuelConsumption + additionalConsumption) <= this.FuelQuantity)
            {
                return String.Format("{0} travelled {1:0.00} km", this.Name, distanceToDrive);
            }
            else
            {
                return String.Format("{0} needs refueling", this.Name, distanceToDrive);
            }
        }
    }
    class Truck : Car
    {
        private double additionalConsumption;
        private double fuelLossIndex;
        public Truck(string name, double fuelQuantity, double fuelConsumption) : base(name, fuelQuantity, fuelConsumption)
        {
            this.additionalConsumption = 1.6;
            this.fuelLossIndex = 0.95;
        }
        public override void Refuel(double quantityToRefuel)
        {
            this.FuelQuantity += quantityToRefuel * fuelLossIndex;
        }
    }
    class Vehicles
    {
        static void Main(string[] args)
        {
            string[] input;
            input = Regex.Split(Console.ReadLine(), @"\s+");
            Car car = new Car(input[0], double.Parse(input[1], CultureInfo.InvariantCulture), double.Parse(input[2], CultureInfo.InvariantCulture));
            input = Regex.Split(Console.ReadLine(), @"\s+");
            Truck truck = new Truck(input[0], double.Parse(input[1], CultureInfo.InvariantCulture), double.Parse(input[2], CultureInfo.InvariantCulture));
            int n = int.Parse(Console.ReadLine());
            string[] command;
            for (int i = 0; i < n; i++)
            {
                command = Regex.Split(Console.ReadLine(), @"\s+");
                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(command[2], CultureInfo.InvariantCulture)));
                    }
                    else if (command[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(command[2], CultureInfo.InvariantCulture)));
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2], CultureInfo.InvariantCulture));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(command[2], CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("{0}", car.GetInfo());
            Console.WriteLine("{0}", truck.GetInfo());
        }
    }
}
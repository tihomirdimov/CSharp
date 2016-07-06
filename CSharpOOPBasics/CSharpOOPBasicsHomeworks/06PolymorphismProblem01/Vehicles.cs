using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _06PolymorphismProblem01
{
    public abstract class Vehicle
    {
        private string name;
        private double fuelQuantity;
        private double fuelConsumption;
        protected Vehicle(string name, double fuelQuantity, double fuelConsumption)
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

        public void Drive(double distanceToDrive)
        {
            if (distanceToDrive * this.FuelConsumption <= this.FuelQuantity)
            {
                Console.WriteLine("{0} travelled {1} km", this.Name, distanceToDrive);
                this.FuelQuantity -= distanceToDrive * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine("{0} needs refueling", this.Name);
            }
        }
        public abstract void Refuel(double quantityToRefuel);
        public double GetFuel()
        {
            return FuelQuantity;
        }
    }
    public class Car : Vehicle
    {
        public Car(string name, double fuelQuantity, double fuelConsumption) : base(name, fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 0.9;
        }
        public override void Refuel(double quantityToRefuel)
        {
            FuelQuantity += quantityToRefuel;
        }
    }
    class Truck : Vehicle
    {
        public Truck(string name, double fuelQuantity, double fuelConsumption) : base(name, fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 1.6;
        }
        public override void Refuel(double quantityToRefuel)
        {
            FuelQuantity += quantityToRefuel * 0.95;
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
                        car.Drive(double.Parse(command[2], CultureInfo.InvariantCulture));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Drive(double.Parse(command[2], CultureInfo.InvariantCulture));
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
            Console.WriteLine("Car: {0:F2}", car.GetFuel());
            Console.WriteLine("Truck: {0:F2}", truck.GetFuel());
        }
    }
}
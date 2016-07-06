using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace _06PolymorphismProblem01
{
    public abstract class Vehicle
    {
        private string name;
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Vehicle(string name, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.name = name;
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;
        }
        public string Name
        {
            get
            {
                return name;
            }
            protected set
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
            protected set
            {
                fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            protected set
            {
                fuelConsumption = value;
            }
        }
        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            set
            {
                tankCapacity = value;
            }
        }
        public void Drive(double distanceToDrive)
        {
            if (distanceToDrive * FuelConsumption <= FuelQuantity)
            {
                Console.WriteLine("{0} travelled {1} km", Name, distanceToDrive);
                FuelQuantity -= distanceToDrive * FuelConsumption;
            }
            else
            {
                Console.WriteLine("{0} needs refueling", Name);
            }
        }
        public abstract void Refuel(double quantityToRefuel);
    }
    public class Car : Vehicle
    {
        public Car(string name, double fuelQuantity, double fuelConsumption, double tankCapacity) : base(name, fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += 0.9;
        }
        public override void Refuel(double quantityToRefuel)
        {
            FuelQuantity += quantityToRefuel;
        }
    }
    public class Truck : Vehicle
    {
        public Truck(string name, double fuelQuantity, double fuelConsumption, double tankCapacity) : base(name, fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += 1.6;
        }
        public override void Refuel(double quantityToRefuel)
        {
            FuelQuantity += quantityToRefuel * 0.95;
        }
    }

    public class Bus : Vehicle
    {
        public Bus(string name, double fuelQuantity, double fuelConsumption, double tankCapacity) : base(name, fuelQuantity, fuelConsumption, tankCapacity)
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
            Car car = new Car(input[0], double.Parse(input[1], CultureInfo.InvariantCulture), double.Parse(input[2], CultureInfo.InvariantCulture), double.Parse(input[2], CultureInfo.InvariantCulture));
            input = Regex.Split(Console.ReadLine(), @"\s+");
            Truck truck = new Truck(input[0], double.Parse(input[1], CultureInfo.InvariantCulture), double.Parse(input[2], CultureInfo.InvariantCulture), double.Parse(input[2], CultureInfo.InvariantCulture));
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
            Console.WriteLine("Car: {0:F2}", car.FuelQuantity);
            Console.WriteLine("Truck: {0:F2}", truck.FuelQuantity);
        }
    }
}
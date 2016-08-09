using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
public class Car
{
    public string model;
    public double fuelAmount;
    public double fuelConsumption;
    public int distanceTraveled = 0;
    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
        this.distanceTraveled = 0;
    }
    public void Drive(int kms)
    {
        if (this.fuelConsumption * kms > this.fuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.distanceTraveled += kms;
            this.fuelAmount -= this.fuelConsumption * kms;
        }
    }
    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:F2} {this.distanceTraveled}";
    }
}
class SpeedRacing
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] currentCar = Regex.Split(Console.ReadLine(), @"\s+");
            string model = currentCar[0];
            double fuelAmount = double.Parse(currentCar[1], CultureInfo.InvariantCulture);
            double fuelConsumption = double.Parse(currentCar[2], CultureInfo.InvariantCulture);
            Car newCar = new Car(model, fuelAmount, fuelConsumption);
            cars.Add(newCar);
        }
        string command = Console.ReadLine();
        while (command != "End")
        {
            string[] input = Regex.Split(command, @"\s+");
            string model = input[1];
            int kms = int.Parse(input[2]);
            cars.FirstOrDefault(c => c.model == model).Drive(kms);
            command = Console.ReadLine();
        }
        cars.ForEach(Console.WriteLine);
    }
}
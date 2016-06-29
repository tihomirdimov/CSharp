using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Employee
{
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email;
    public int age;
    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.age = -1;
        this.email = "n/a";
    }
    public override string ToString()
    {
        return $"{this.name} {this.salary:F2} {this.email} {this.age}";
    }
}
class CompanyRoster
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < lines; i++)
        {
            string[] input = Regex.Split(Console.ReadLine(), @"\s+");
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];
            Employee newEmployee = new Employee(name, salary, position, department);
            if (input.Length > 5)
            {
                int age = int.Parse(input[5]);
                newEmployee.age = age;
            }
            if (input.Length > 4)
            {
                var ageOrEmail = input[4];
                if (ageOrEmail.Contains("@"))
                {
                    newEmployee.email = ageOrEmail;
                }
                else
                {
                    newEmployee.age = int.Parse(ageOrEmail);
                }

            }
            if (input.Length > 5)
            {
                newEmployee.age = int.Parse(input[5]);
            }
            employees.Add(newEmployee);
        }
        var bestDep = employees
            .GroupBy(e => e.department)
            .Select(e => new
            {
                DepName = e.Key,
                AverageSalary = e.Average(emp => emp.salary),
                Employees = e.OrderByDescending(em => em.salary)
            }).OrderByDescending(e => e.AverageSalary).FirstOrDefault();
        Console.WriteLine($"Highest Average Salary: {bestDep.DepName}");
        foreach (var empl in bestDep.Employees)
        {
            Console.WriteLine(empl.ToString());
        }
    }
}
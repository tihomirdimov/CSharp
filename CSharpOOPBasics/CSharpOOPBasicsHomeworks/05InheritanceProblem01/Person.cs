using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Person
{
    private string name;
    private int age;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new AggregateException("Name’s length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    public virtual int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }
    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}
public class Child : Person
{
    public Child(string name, int age) : base(name, age)
    {
    }

    public override int Age
    {
        get
        {
            return base.Age;
        }

        set
        {
            if (value > 15)
            {
                throw new ArgumentException("Child’s age must be less than 15!");
            }
            base.Age = value;
        }
    }

}
class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

}
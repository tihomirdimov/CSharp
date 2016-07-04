using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Person
{
    string name;
    int age;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public virtual string Name
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
            else
            {
                name = value;
            }
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
            else
            {
                age = value;
            }
        }
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                             this.Name,
                             this.age));

        return stringBuilder.ToString();
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
            else
            {
                base.Age = value;
            }
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
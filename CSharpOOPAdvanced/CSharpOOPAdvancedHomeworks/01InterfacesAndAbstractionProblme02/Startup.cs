﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01InterfacesAndAbstractionProblme02
{
    interface IPerson
    {
        string Name { get; }
        int Age { get; }
    }

    interface IIdentifiable
    {
        string Id { get; }
    }

    interface IBirthable
    {
        string Birthdate { get; }
    }

    class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
    class Startup
    {
        static void Main()
        {
            Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
            Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
            PropertyInfo[] properties = identifiableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            properties = birthableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
        }
    }
}

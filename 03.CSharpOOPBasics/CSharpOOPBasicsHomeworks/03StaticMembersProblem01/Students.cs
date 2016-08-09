using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03StaticMembersProblem01
{
    class Student
    {
        static int counter = 0;
        string name;
        public static int getCounter
        {
            get { return Student.counter; }
        }
        public Student(string name)
        {
            Student.counter++;
            this.name = name;
        }
    }
    class Students
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                new Student(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(Student.getCounter);
        }
    }
}

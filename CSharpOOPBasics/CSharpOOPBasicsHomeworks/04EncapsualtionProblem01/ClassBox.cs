using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _04EncapsulationProblem01
{
    class Box
    {
        private double lenght;
        private double widht;
        private double height;
        public Box(double lenght, double width, double height)
        {
            this.lenght = lenght;
            this.widht = width;
            this.height = height;
        }
        internal static string Calculate(double lenght, double width, double height)
        {
            string result = String.Format("Surface Area - {0:0.00}\n" +
                                          "Lateral Surface Area - {1:0.00}\n" +
                                          "Volume - {2:0.00}",
                                          2 * lenght * width + 2 * lenght * height + 2 * width * height,
                                          2 * lenght * height + 2 * width * height,
                                          lenght * width * height);
            return result;
        }
    }

    class ClassBox
    {
        static void Main(string[] args)
        {
            {
                Type boxType = typeof(Box);
                FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine(fields.Count());
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine(Box.Calculate(lenght, width, height));
            }
        }
    }
}

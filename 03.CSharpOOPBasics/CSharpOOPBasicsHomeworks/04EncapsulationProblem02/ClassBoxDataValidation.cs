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
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("length cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
            }
        }
        public string Calculate()
        {
            string result = String.Format("Surface Area - {0:0.00}\n" +
                                          "Lateral Surface Area - {1:0.00}\n" +
                                          "Volume - {2:0.00}",
                                          2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height,
                                          2 * this.length * this.height + 2 * this.width * this.height,
                                          this.length * this.width * this.height);
            return result;
        }
    }

    class ClassBoxDataValidation
    {
        static void Main(string[] args)
        {
            {
                Type boxType = typeof(Box);
                FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine(fields.Count());
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                try
                {
                    Box box = new Box(length, width, height);
                    Console.WriteLine(box.Calculate());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
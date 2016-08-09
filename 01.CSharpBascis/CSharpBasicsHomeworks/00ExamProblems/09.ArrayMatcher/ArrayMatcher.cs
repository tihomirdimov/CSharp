//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ArrayMatcher
{
    class ArrayMatcher
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split('\\');
            string arr1 = values[0];
            string arr2 = values[1];
            string command = values[2];
            List<char> result = new List<char>();
            if (command == "join")
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i] == arr2[j])
                        {
                            result.Add(arr1[i]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                result.Sort();
                foreach (char value in result)
                {
                    Console.Write(value);
                }
            }
            if (command == "right exclude")
            {
                int counter = 0;
                for (int i = 0; i < arr1.Length; i++)
                {
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i] != arr2[j])
                        {
                            counter++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (counter == arr2.Length)
                    {
                        result.Add(arr1[i]);
                    }
                    counter = 0;
                }
                result.Sort();
                foreach (char value in result)
                {
                    Console.Write(value);
                }
            }
            if (command == "left exclude")
            {
                int counter = 0;
                for (int i = 0; i < arr2.Length; i++)
                {
                    for (int j = 0; j < arr1.Length; j++)
                    {
                        if (arr2[i] != arr1[j])
                        {
                            counter++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (counter == arr1.Length)
                    {
                        result.Add(arr2[i]);
                    }
                    counter = 0;
                }
                result.Sort();
                foreach (char value in result)
                {
                    Console.Write(value);
                }
            }
        }
    }
}

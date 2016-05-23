using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem06AMinerTask
{
    class Problem06AMinerTask
    {
        public static Dictionary<string, int> resources = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string tempResource = "";
            int tempQuantity = 0;
            int counter = 1;
            while (input != "stop")
            {
                if (counter % 2 != 0)
                {
                    tempResource = input;
                    counter++;
                }
                else
                {
                    tempQuantity = int.Parse(input);
                    isInDictionary(tempResource, tempQuantity);
                    counter++;
                }
                input = Console.ReadLine();
            }
            foreach (KeyValuePair<string, int> resource in resources)
            {
                Console.WriteLine("{0} -> {1}", resource.Key, resource.Value );
            }
        }
        public static void isInDictionary(string tempStr, int tempInt)
        {
            if (resources.ContainsKey(tempStr))
            {
                resources[tempStr] += tempInt;
            }
            else
            {
                resources.Add(tempStr, tempInt);
            }
        }
    }
}
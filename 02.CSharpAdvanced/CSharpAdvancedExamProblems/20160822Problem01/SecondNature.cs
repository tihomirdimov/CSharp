using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160822Problem01
{
    class SecondNature
    {
        static void Main()
        {
            int[] flowersData = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int[] bucketsData = Console.ReadLine().Split().Select(x=> int.Parse(x)).ToArray();
            Queue<int> flowers = new Queue<int>();
            Stack<int> buckets = new Stack<int>();
            foreach (var flower in flowersData)
            {
                flowers.Enqueue(flower);
            }
            foreach (var bucket in bucketsData)
            {
                buckets.Push(bucket);
            }
        }
    }
}

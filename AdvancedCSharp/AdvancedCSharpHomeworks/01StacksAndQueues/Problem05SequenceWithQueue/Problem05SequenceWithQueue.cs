using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem05SequenceWithQueue
{
    static void Main(string[] args)
    {
        long s = long.Parse(Console.ReadLine());
        Queue<long> numbers = new Queue<long>();
        numbers.Enqueue(s);
        List<long> toPrint = new List<long>();
        toPrint.Add(s);
        while (toPrint.Count < 50)
        {
            long k = numbers.Peek() + 1;
            long l = (2 * (numbers.Peek())) + 1;
            long m = numbers.Peek() + 2;
            numbers.Enqueue(k);
            numbers.Enqueue(l);
            numbers.Enqueue(m);
            toPrint.Add(k);
            toPrint.Add(l);
            toPrint.Add(m);
            numbers.Dequeue();
        }
        for (int i = 0; i < 50; i++)
        {
            Console.Write("{0} ", toPrint[i]);
        }
    }
}
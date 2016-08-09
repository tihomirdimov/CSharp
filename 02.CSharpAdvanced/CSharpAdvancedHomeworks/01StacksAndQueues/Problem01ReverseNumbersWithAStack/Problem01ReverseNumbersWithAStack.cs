using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem01ReverseNumbersWithAStack
{

    public static void Main()
    {
        int[] numbers = Console
            .ReadLine()
            .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(item => int.Parse(item))
            .ToArray();
        Stack<int> numbersToPrint = new Stack<int>();
        foreach (int number in numbers)
        {
            numbersToPrint.Push(number);
        }
        while (numbersToPrint.Count > 0)
        {
            Console.Write("{0} ", numbersToPrint.Pop());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem03MaximumElement
{
    static void Main(string[] args)
    {
        int queriesNum = int.Parse(Console.ReadLine());
        Stack<long> numbers = new Stack<long>();
        for (long i = 0; i < queriesNum; i++)
        {
            long[] elementsToProcess = Console
               .ReadLine()
               .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(item => long.Parse(item))
               .ToArray();
            processElement(elementsToProcess, numbers);
        }
    }
    public static void processElement(long[] elements, Stack<long> numbersStack)
    {
        if (elements.Length == 1)
        {
            if (elements[0] == 2)
            {
                numbersStack.Pop();
            }
            else
            {
                long max = checkMax(numbersStack);
                Console.WriteLine(max);
            }
        }
        else
        {
            numbersStack.Push(elements[1]);
        }
    }
    public static long checkMax(Stack<long> numbersStack)
    {
        long maxNum = 0;
        foreach (long number in numbersStack)
        {
            if (number > maxNum)
            {
                maxNum = number;
            }
        }
        return maxNum;
    }
}
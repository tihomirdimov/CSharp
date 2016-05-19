using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem02BasicStackOperations
{
    static void Main(string[] args)
    {
        int[] elementsToProcess = Console
               .ReadLine()
               .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(item => int.Parse(item))
               .ToArray();
        int elementToPush = elementsToProcess[0];
        int elementToPop = elementsToProcess[1];
        int elementToCheck = elementsToProcess[2];
        int[] stackNumbers = Console
            .ReadLine()
            .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(item => int.Parse(item))
            .ToArray();
        Stack<int> numbers = new Stack<int>();
        for (int i = 0; i < elementToPush; i++)
        {
            numbers.Push(stackNumbers[i]);
        }
        while (elementToPop > 0)
        {
            numbers.Pop();
            elementToPop--;
        }
        if (numbers.Contains(elementToCheck))
        {
            Console.WriteLine("true");
        }
        else
        {
            if (numbers.Count() == 0)
            {
                Console.WriteLine(numbers.Count());
            }
            else
            {
                int min = numbers.Peek();
                foreach (int number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
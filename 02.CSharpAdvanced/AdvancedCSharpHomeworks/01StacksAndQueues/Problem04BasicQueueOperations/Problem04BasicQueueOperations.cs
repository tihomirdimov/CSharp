using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem04BasicQueueOperations
{
    static void Main(string[] args)
    {
        int[] elementsToProcess = Console
                .ReadLine()
                .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => int.Parse(item))
                .ToArray();
        int elementToEnqueue = elementsToProcess[0];
        int elementToDequeue = elementsToProcess[1];
        int elementToCheck = elementsToProcess[2];
        int[] queueNumbers = Console
            .ReadLine()
            .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(item => int.Parse(item))
            .ToArray();
        Queue<int> numbers = new Queue<int>();
        for (int i = 0; i < elementToEnqueue; i++)
        {
            numbers.Enqueue(queueNumbers[i]);
        }
        while (elementToDequeue > 0)
        {
            numbers.Dequeue();
            elementToDequeue--;
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
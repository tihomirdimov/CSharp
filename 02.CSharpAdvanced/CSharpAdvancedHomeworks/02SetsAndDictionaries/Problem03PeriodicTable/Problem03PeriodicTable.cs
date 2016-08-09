using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem03PeriodicTable
{
    public static SortedSet<string> uniqueElements = new SortedSet<string>();
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] elements = Console
            .ReadLine()
            .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
            foreach (string element in elements)
            {
                containsElement(element);
            }
        }
        foreach (string uniqueElement in uniqueElements)
        {
            Console.Write("{0} ", uniqueElement);
        }
    }
    public static void containsElement(string currentElement)
    {
        if (!uniqueElements.Contains(currentElement))
        {
            uniqueElements.Add(currentElement);
        }
    }
}
using System;
class PlayWithIntDoubleAndString
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please choose a type:\n1-- > int\n2-- > double\n3-- > string");
        int digit = int.Parse(Console.ReadLine());
        switch (digit)
        {
            case 1:
                Console.WriteLine("Please enter an integer:");
                int caseInteger = int.Parse(Console.ReadLine());
                Console.WriteLine(caseInteger+1);
                break;
            case 2:
                Console.WriteLine("Please enter a double:");
                double caseDouble = double.Parse(Console.ReadLine());
                Console.WriteLine(caseDouble+1);
                break;
            case 3:
                Console.WriteLine("Please enter a string:");
                int caseString = int.Parse(Console.ReadLine());
                Console.WriteLine("{0}*", caseString);
                break;
            default: Console.WriteLine("Please type 1, 2 or 3 and press enter"); break;
        }
    }
}
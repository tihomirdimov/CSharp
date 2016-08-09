//HW source: SoftUni Forum
using System;
class ModifyBitAtGivenPosition
{
    static void Main()
    {
        Console.Write("Enter your number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Check bit of position: ");
        int position = int.Parse(Console.ReadLine());
        Console.Write("Value of bit [0 or 1]: ");
        int value = int.Parse(Console.ReadLine());

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));

        if (value == 1)
        {
            int setOne = 1 << position;
            int foundBitOne = number | setOne;
            Console.WriteLine(Convert.ToString(foundBitOne, 2).PadLeft(16, '0'));
            Console.WriteLine(foundBitOne);
        }
        else
        {
            int setZero = ~(1 << position);
            int foundBitZero = number & setZero;
            Console.WriteLine(Convert.ToString(foundBitZero, 2).PadLeft(16, '0'));
            Console.WriteLine(foundBitZero);
        }
    }
}
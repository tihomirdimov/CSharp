using System;
class ExtractBit3
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int n = int.Parse(Console.ReadLine());
        int bitNo = 3;
        int extractedBit = n >> bitNo;
        Console.WriteLine(extractedBit & 1);
    }
}
using System;
class DecimalToBinaryNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a decimal number: ");
        long decimalNo = long.Parse(Console.ReadLine());
        long remainder;
        string binaryNo = string.Empty;
        while (decimalNo > 0)
        {
            remainder = decimalNo % 2;
            decimalNo /= 2;
            binaryNo = remainder.ToString() + binaryNo;
        }
        Console.WriteLine("Decimal value: {0}", binaryNo);
    }
}
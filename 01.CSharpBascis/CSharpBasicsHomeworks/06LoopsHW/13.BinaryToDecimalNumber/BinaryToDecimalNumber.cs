using System;
class BinaryToDecimalNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pleas enter binary number");
        string binaryStr = Console.ReadLine();
        byte[] binaryNo = new byte[binaryStr.Length];
        for (int i = 0; i < binaryStr.Length; i++)
        {
            binaryNo[i] = byte.Parse(Convert.ToString((binaryStr[i])));
        }
        Array.Reverse(binaryNo);
        double decimalNo = 0;
        double power = 0;
        for (int i = 0; i < binaryNo.Length; i++)
        {
            //Console.WriteLine("{0} {1}", i, binaryNo[i]);
            power = Math.Pow(2, i);
            decimalNo += binaryNo[i] * power;
        }
        Console.WriteLine("Decimal value: {0}", decimalNo);
    }
}
using System;
class DecimalToHexadecimalNumber
{
    static void Main()
    {
        long decimalNo = long.Parse(Console.ReadLine());
        long remainder = 0;
        string hexadecimalNo = null;

        while (decimalNo > 0)
        {
            remainder = decimalNo % 16;
            switch (remainder)
            {
                case 10:
                    hexadecimalNo = 'A' + hexadecimalNo;
                    break;
                case 11:
                    hexadecimalNo = 'B' + hexadecimalNo;
                    break;
                case 12:
                    hexadecimalNo = 'C' + hexadecimalNo;
                    break;
                case 13:
                    hexadecimalNo = 'D' + hexadecimalNo;
                    break;
                case 14:
                    hexadecimalNo = 'E' + hexadecimalNo;
                    break;
                case 15:
                    hexadecimalNo = 'F' + hexadecimalNo;
                    break;
                default:
                    hexadecimalNo = remainder.ToString() + hexadecimalNo;
                    break;
            }
            decimalNo /= 16;
        }
        Console.WriteLine(hexadecimalNo);
    }
}
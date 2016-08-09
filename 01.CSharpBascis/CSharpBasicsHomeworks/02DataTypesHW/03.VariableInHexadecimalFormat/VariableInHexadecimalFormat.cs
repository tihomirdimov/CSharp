using System;
class VariableInHexadecimalFormat
{
    static void Main()
    {
        var hexStr = "FE";
        long dec = Convert.ToInt64(hexStr, 16);
        Console.WriteLine(dec);
    }
}
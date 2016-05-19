using System;
class StringsAndObjects
{
    static void Main()
    {
        string var1 = "Hello";
        string var2 = "World";
        object conc = var1 + " " + var2;
        Console.WriteLine(conc);
        string concStr = (string) conc;
        Console.WriteLine(concStr);
    }
}

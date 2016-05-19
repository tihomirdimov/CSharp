using System;
class NullValuesArithmetic
{
    static void Main()
    {
        int? a = null;
        double? b = null;
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(a + 10);
        Console.WriteLine(b + 10);
        Console.WriteLine(a + null);
        Console.WriteLine(b + null);
    }
}


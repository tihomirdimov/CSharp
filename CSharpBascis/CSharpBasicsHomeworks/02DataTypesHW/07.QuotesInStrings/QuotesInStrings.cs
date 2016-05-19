using System;
class QuotesInStrings
{
    static void Main(string[] args)
    {
        string var1 = "The \"use\" of quotations causes difficulties.";
        string var2 = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(var1);
        Console.WriteLine(var2);
    }
}

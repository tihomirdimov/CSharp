using System;
class ExchangeVariableValues
{
    static void Main()
    {
    var a = 5;
    var b = 10;
    Console.WriteLine("Before:\na = {0}\nb = {1}", a, b);
    Console.WriteLine("After:\na = {0}\nb = {1}", a * 2, b / 2);
    }
}

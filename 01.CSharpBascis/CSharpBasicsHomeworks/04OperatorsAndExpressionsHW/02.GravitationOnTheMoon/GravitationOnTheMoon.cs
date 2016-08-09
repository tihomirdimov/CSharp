using System;
class GravitationOnTheMoon
{
    static void Main()
    {
        double weight = double.Parse(Console.ReadLine());
        double earthGravity = 9.81;
        double moonGravity = 0.17 * earthGravity;
        double moonweight = (weight / earthGravity) * moonGravity;
        Console.WriteLine(moonweight);
    }
}
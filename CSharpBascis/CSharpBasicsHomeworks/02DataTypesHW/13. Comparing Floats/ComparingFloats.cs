using System;
//solution found in Pastebin here -> http://pastebin.com/v36rRsVF
class ComparingFloats
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        float firstNumber = float.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        float secondNumber = float.Parse(Console.ReadLine());
        double difference = Math.Abs(firstNumber - secondNumber);
        double threshold = 0.000001;
        bool areEqual = difference < threshold;
        Console.WriteLine(areEqual);
    }
}


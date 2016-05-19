using System;
class RandomizeTheNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter positive number");
        int number = int.Parse(Console.ReadLine());
        int[] numbers = new int[number];
        for (int i = 0; i < number; i++)
        {
            numbers[i] = i+1;
        }
        Console.WriteLine(string.Join(" ", numbers));
        Random random = new Random();
        for (int i = 0; i < number; i++)
        {
            int randomIndex = random.Next(0, number);
            int temp = numbers[randomIndex];
            numbers[randomIndex] = numbers[i];
            numbers[i] = temp;
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}
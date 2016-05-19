using System;
using System.Collections.Generic;
using System.Linq;
class LongestNonDecreasingSubsequence
{
    static void Main()
    {
        Console.WriteLine("Please enter sequence of numbers");
        string[] input = Console.ReadLine().Split();
        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = Convert.ToInt32(input[i]);
        }
        //Опитах се да напиша задачата, ползвайки следната логиката, но не успях:
        //1.Създаваме лист-матрица с начална стойност за всеки ред, съответният индекс входящия масив (numbers[0],numbers[1]... numbers[n])
        //2.Обхождаме входящия масив като започваме от съответния индекс
        //3.В матрицата записваме само нарастващите стойности спрямо стойността на съответния индекс
        //4.Вече имаме "матрица" с различен брой на колони за всеки ред
        //5.Намираме реда с най-голям length (най-много колони) и го отпечатваме
        //6.Това е и редът с най-много последователно не намаляващи числа

    }
}
using System;
class KingOfThieves
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n < 3 || n > 59 || (n % 2 == 0))
        {
            Console.WriteLine("Please enter odd number greater than 3 and smaller than 59");
        }
        else
        {
            char gem = char.Parse(Console.ReadLine());
            char side = '-';
            //top body
            int topsidecounter = (n - 1) / 2;
            int topgemcounter = 1;
            for (int i = 0; i <= (n - 1)/2-1; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string(side, topsidecounter), new string(gem, topgemcounter));
                topsidecounter-=1;
                topgemcounter+=2;
            }
            //middle
            Console.WriteLine("{0}", new string(gem, n));
            //bottom body
            int bottomsidecounter = 1;
            int bottomgemcounter = n-2;
            for (int i = 0; i <= (n - 1) / 2 - 1; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string(side, bottomsidecounter), new string(gem, bottomgemcounter));
                bottomsidecounter += 1;
                bottomgemcounter -= 2;
            }
        }
    }
}
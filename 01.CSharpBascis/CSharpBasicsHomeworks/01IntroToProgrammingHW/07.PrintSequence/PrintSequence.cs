using System;
class Program
{
    static void Main()
    {
        int x = 2;
        int y = -3;
        for (int i = 1; i < 6; i++)
        { 
            Console.Write(x+" "+y+" ");
            x=x+2;
            y=y-2;
        }
    }
}

using System;
class PrintTheAsciiTable
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        for (var i = 0; i <= 255; i++)
        {
            string asciiChar = @"ASCII charachter no. " + i + " is: " + (char)i;
            //avoid using the new line in the output
            if ((char)i == '\n')
            {
                asciiChar = @"ASCII charachter no. " + i + " is: newline"; 
                Console.WriteLine(asciiChar);
            }
            else
            {
                Console.WriteLine(asciiChar);
            }
            
        }
    }
}

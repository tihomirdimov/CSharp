using System;
class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var copyright = "\u00A9";
        Console.WriteLine("   {0}\n  {0} {0}\n {0}   {0}\n{0} {0} {0} {0}", copyright);
        //works perfect with console window set to Lucida Console font
    }
}
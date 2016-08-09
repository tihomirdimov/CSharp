using System;
class BooleanVariable
{
    static void Main(string[] args)
    {
        bool isFemale;
        char myGender = 'm';
        if (myGender == 'm')
        {
           isFemale = false;
        }
        else
        {
            isFemale = true;
        }
        Console.WriteLine(isFemale.ToString().ToLower());
        //output is falce, since my gender is male compared to female as written in the taks description :)
    }
}

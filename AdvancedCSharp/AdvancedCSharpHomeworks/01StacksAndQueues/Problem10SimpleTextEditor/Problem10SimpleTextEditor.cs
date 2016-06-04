using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem10SimpleTextEditor
{
    public static Stack<string> text = new Stack<string>();
    static void Main()
    {
        int tasksNum = int.Parse(Console.ReadLine());
        for (int i = 0; i < tasksNum; i++)
        {
            string input = Console.ReadLine();
            string[] commandLine = input.Split(' ');
            applyCommand(commandLine);
        }
    }
    public static void applyCommand(string[] input)
    {
        switch (input[0])
        {
            case "1":
                appendText(input[1]);
                break;
            case "2":
                eraseText(input[1]);
                break;
            case "3":
                returnElement(input[1]);
                break;
            case "4":
                text.Pop();
                break;
        }
    }
    public static void appendText(string inputText)
    {
        if (text.Count > 0)
        {
            text.Push(text.Peek().ToString() + inputText);
        }
        else
        {
            text.Push(inputText);
        }
    }
    public static void eraseText(string inputText)
    {
        int elementsToErase = int.Parse(inputText);
        string tempText = text.Peek().Substring(0,text.Peek().ToString().Length-elementsToErase);
        text.Push(tempText);
    }
    public static void returnElement(string inputText)
    {
        int elementsToReturn = int.Parse(inputText);
        Console.WriteLine(text.Peek().ElementAt(elementsToReturn-1));
    }
}
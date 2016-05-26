using System;
using System.IO;

class Tester
{
    public static void CompareContent(string userOutputPath, string expectedOutputPath)
    {
        Console.WriteLine("Reading files....");
        string mismatchPath = GetMismatchPath(expectedOutputPath);
        string[] actualOutputLines = File.ReadAllLines(userOutputPath);
        string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);
        bool hasMismatch;
        string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);
    }
    private static string GetMismatchPath(string expectedOutputPath)
    {
        int indexOf = expectedOutputPath.LastIndexOf('\\');
        string directoryPath = expectedOutputPath.Substring(0, indexOf);
        string finalPath = directoryPath + @"\Mismatches.txt";
        return finalPath;
    }
    public static string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
    {
        hasMismatch = false;
        string output = string.Empty;
        string[] x = actualOutputLines;
        return x;
    }
}
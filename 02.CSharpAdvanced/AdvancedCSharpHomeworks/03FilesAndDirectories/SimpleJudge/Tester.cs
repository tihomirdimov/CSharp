using System;
using System.Linq;
using System.IO;

class Tester
{
    static void Main()
    {
        Test.CompareContent("test1.txt, ", "test2.txt");
    }
    public static void CompareContent(string userOutputPath, string expectedOutputPath)
    {
        Console.WriteLine("Reading files...");
        string mismatchPath = GetMismatchPath(expectedOutputPath);
        string[] actualOutputLines = File.ReadAllLines(userOutputPath);
        string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);
        bool hasMismatch;
        string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);
        PtintOutput(mismatches, hasMismatch, mismatchPath);
        Console.WriteLine("Files Read!");
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
        string[] mismatches = new string[actualOutputLines.Lenght];
        Console.WriteLine("Comparing files...");
        for (int index = 0; index < actualOutputLines.Lenght; index++)
        {
            string actualLine = actualOutputLines[index];
            string expectedLine = expectedOutputLines[index];
            if (!actualLine.equals(expectedLine))
            {
                output = string.Format("Mismatch at line {0} -- expected: \"{1}\", actual \"{2}\", ",, index, expectedLine, actualLine);
                output += Enviornment.NewLine;
                hasMismatch = true;
            }
            else
            {
                output = actualLine;
                output += Enviornment.NewLine;
            }
            mismatches[index] = output;
        }
        return mismatches;
    }
    private static void PtintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
    {
        if (hasMismatch)
        {
            foreach (var line in mismatches)
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines(mismatchPath, mismatches);
            return;
        }
    }
}
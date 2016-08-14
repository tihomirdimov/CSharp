using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20160613Problem04
{
    class JediDreams
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder lines = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                lines.Append(Console.ReadLine());
            }
            string text = lines.ToString();
            string declaredMethodPattern = @"static\s+[\w<>\[\],]+\s+(\w*[A-Z]{1}\w*)";
            string invokedMethodPattern = @"(\w*[A-Z]{1}\w*)\s*(?:\()";
            Regex declaredMethodRegex = new Regex(declaredMethodPattern);
            Regex invokedMethodsRegex = new Regex(invokedMethodPattern);
            Dictionary<string, List<string>> declaredMethods = new Dictionary<string, List<string>>();
            MatchCollection declaredMethodsMatchCollection = declaredMethodRegex.Matches(text.ToString());
            for (int i = 0; i < declaredMethodsMatchCollection.Count; i++)
            {
                var currentDeclaredMethod = declaredMethodsMatchCollection[i].Groups[1].Value;
                declaredMethods.Add(currentDeclaredMethod, new List<string>());
                int currentMethodLength = declaredMethodsMatchCollection[i].Groups[0].Value.Length;
                int startIndex = text.IndexOf(declaredMethodsMatchCollection[i].Groups[0].Value) + currentMethodLength;
                int subStringlength;
                if (i == declaredMethodsMatchCollection.Count - 1)
                {
                    subStringlength = text.Length - 1 - startIndex;
                }
                else
                {
                    subStringlength = text.IndexOf(declaredMethodsMatchCollection[i + 1].Groups[0].Value) - startIndex;
                }
                var methodBody = text.Substring(startIndex, subStringlength);
                MatchCollection invokedMethodsMatchCollection = invokedMethodsRegex.Matches(methodBody);
                foreach (Match invokedMethod in invokedMethodsMatchCollection)
                {
                    var currentInvokedMethod = invokedMethod.Groups[1].Value;
                    declaredMethods[currentDeclaredMethod].Add(currentInvokedMethod);
                }
            }
            var printDeclared = declaredMethods.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToList();
            foreach (var item in printDeclared)
            {
                if (item.Value.Count < 1)
                {
                    Console.WriteLine("{0} -> None", item.Key);
                }
                else
                {
                    Console.WriteLine("{0} -> {1} -> {2}", item.Key, item.Value.Count, string.Join(", ", item.Value.OrderBy(x => x)));
                }
            }
        }
    }
}

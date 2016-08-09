using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem07FixEmails
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<string, string> emails = new Dictionary<string, string>();
        int counter = 1;
        string tempName = "";
        string tempEmail = "";
        while (input != "stop")
        {
            if (counter % 2 != 0)
            {
                tempName = input;
                counter++;
                input = Console.ReadLine();
            }
            else
            {
                tempEmail = input;
                if (isValid(tempEmail))
                {
                    emails.Add(tempName, tempEmail);
                    counter++;
                    input = Console.ReadLine();
                }
                else
                {
                    counter++;
                    input = Console.ReadLine();
                }
            }
        }
        foreach (KeyValuePair<string, string> email in emails) {
            Console.WriteLine("{0} -> {1}", email.Key, email.Value);
        }

    }
    public static bool isValid(string emailToCheck)
    {
        if ((emailToCheck.Substring(emailToCheck.Length - 2, 2) == "us") || (emailToCheck.Substring(emailToCheck.Length - 2, 2) == "uk"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
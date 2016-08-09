//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _14.DecryptTheMessages
{
    class DecryptTheMessages
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (input.ToUpper() != "START")
            {
                input = Console.ReadLine();
            }
            int counter = 0;
            StringBuilder decryptedMessage = new StringBuilder();
            while (input.ToUpper() != "END")
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                else if (input.ToUpper() == "END")
                {
                    break;
                }
                else
                {
                    counter++;
                    input = input.Replace('+', ' ').Replace('%', ',').Replace('&', '.').Replace('#', '?').Replace('$', '!');
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        if ((input[i] >= 'A' && input[i] <= 'M') || (input[i] >= 'a' && input[i] <= 'm'))
                        {
                            decryptedMessage.Append((char)(input[i] + 13));
                        }
                        else if ((input[i] >= 'N' && input[i] <= 'Z') || (input[i] >= 'n' && input[i] <= 'z'))
                        {
                            decryptedMessage.Append((char)(input[i] - 13));
                        }
                        else
                        {
                            decryptedMessage.Append(input[i]);
                        }
                    }
                    decryptedMessage.AppendLine();
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No message received.");
            }
            else
            {
                Console.WriteLine("Total number of messages: {0}", counter);
                decryptedMessage.ToString();
                Console.Write(decryptedMessage);
            }
        }
    }
}
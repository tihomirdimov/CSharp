//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.EncryptTheMessages
{
    class EncryptTheMessages
    {
        static void Main(string[] args)
        {
            {
                var input = Console.ReadLine();
                while (input.ToUpper() != "START")
                {
                    input = Console.ReadLine();
                }
                int counter = 0;
                StringBuilder encryptedMessage = new StringBuilder();
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
                        input = input.Replace(' ', '+').Replace(',', '%').Replace('.', '&').Replace('?', '#').Replace('!', '$');
                        for (int i = input.Length - 1; i >= 0; i--)
                        {
                            if ((input[i] >= 'A' && input[i] <= 'M') || (input[i] >= 'a' && input[i] <= 'm'))
                            {
                                encryptedMessage.Append((char)(input[i] + 13));
                            }
                            else if ((input[i] >= 'N' && input[i] <= 'Z') || (input[i] >= 'n' && input[i] <= 'z'))
                            {
                                encryptedMessage.Append((char)(input[i] - 13));
                            }
                            else
                            {
                                encryptedMessage.Append(input[i]);
                            }
                        }
                        encryptedMessage.AppendLine();
                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("No messages sent.");
                }
                else
                {
                    Console.WriteLine("Total number of messages: {0}", counter);
                    encryptedMessage.ToString();
                    Console.Write(encryptedMessage);
                }
            }
        }
    }
}
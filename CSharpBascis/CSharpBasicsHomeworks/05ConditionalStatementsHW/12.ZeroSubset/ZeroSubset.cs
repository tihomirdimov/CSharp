//source SoftUni forum, some modification added
using System;
class ZeroSubset
{
    static void Main()
    {
        Console.WriteLine("Please enter Five numbers.");
        int[] numbers = new int[5];
        int n = numbers.Length;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Number {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        bool result = false;
        if (numbers[0] == 0 && numbers[1] == 0 && numbers[2] == 0 && numbers[3] == 0 && numbers[4] == 0)
        {
            Console.WriteLine("0 + 0 + 0 + 0 + 0 = 0");
            result = true;
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[i] + numbers[j] == 0)
                    {
                        Console.WriteLine("{0} + {1} = 0", numbers[i], numbers[j]);
                        result = true;
                    }
                }

            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = 0", numbers[i], numbers[j], numbers[k]);
                            result = true;
                        }
                    }

                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        for (int l = k + 1; l < n; l++)
                        {
                            if (numbers[i] + numbers[j] + numbers[k] + numbers[l] == 0)
                            {
                                Console.WriteLine("{0} + {1} + {2} + {3} = 0", numbers[i], numbers[j], numbers[k], numbers[l]);
                                result = true;
                            }
                        }
                    }
                }
            }
            if (numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 0)
            {
                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
                result = true;
            }

        }
        if (!result)
        {
            Console.WriteLine("no zero subset");
            Console.WriteLine();
        }
    }
}
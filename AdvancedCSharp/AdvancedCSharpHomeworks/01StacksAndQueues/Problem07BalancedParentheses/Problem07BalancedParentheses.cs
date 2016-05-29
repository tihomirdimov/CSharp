using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem07BalancedParentheses
{
    public static Stack<char> left = new Stack<char>();
    public static Stack<char> right = new Stack<char>();
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        bool isBalanced = false;
        if (input.Length % 2 != 0)
        {
            isBalanced = false;
        }
        else
        {
            for (int i = (input.Length / 2) - 1; i >= 0; i--)
            {
                left.Push(input[i]);
            }
            for (int i = (input.Length / 2); i < input.Length; i++)
            {
                right.Push(input[i]);
            }
            for (int i = 1; i <= (input.Length / 2); i++)
            {
                if (CheckParentheses(left, right))
                {
                    isBalanced = true;
                    continue;
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }
        }
        if (isBalanced)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
    public static bool CheckParentheses(Stack<char> left, Stack<char> right)
    {
        if (Math.Abs(right.Peek() - left.Peek()) == 2 || Math.Abs(right.Peek() - left.Peek()) == 1)
        {
            left.Pop();
            right.Pop();
            return true;
        }
        else
        {
            return false;
        }
    }
}
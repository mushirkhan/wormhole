using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

    public class Solution
    {
        public bool IsDigit(char c)
        {
            if (c == ' ' || c == '+' || c == '-' || c == ')' || c == '(')
            {
                return false;
            }
            return true;
        }
        public int Calculate(string s)
        {
            int result = 0;
            int lastOperator = 1;
            char space = ' ';
            char brackOpen = '(';
            char brackClose = ')';
            char plus = '+';
            char minus = '-';
            int carryValue = 0;
            Stack<int> bracketStack = new Stack<int>();
            for (int index = 0; index < s.Length; index++)
            {
                int peekVal = 0;

                if (!string.Equals(space, s[index]))
                {
                    if (string.Equals(brackOpen, s[index]))
                    {
                        bracketStack.Push(lastOperator);
                    }
                    else if (string.Equals(brackClose, s[index]))
                    {
                        bracketStack.Pop();
                    }
                    else if (string.Equals(plus, s[index]))
                    {
                        if (bracketStack.Count > 0)
                        {
                            peekVal = bracketStack.Peek();
                            lastOperator = 1 * peekVal;
                        }
                        else
                        {
                            lastOperator = 1;
                        }
                    }
                    else if (string.Equals(minus, s[index]))
                    {
                        if (bracketStack.Count > 0)
                        {
                            peekVal = bracketStack.Peek();
                            lastOperator = -1 * peekVal;
                        }
                        else
                        {
                            lastOperator = -1;
                        }
                    }
                    else
                    {
                        bool isNextDigit = false;
                        int value = (int)char.GetNumericValue(s[index]);
                        if(index + 1 < s.Length)
                        {
                            isNextDigit = IsDigit(s[index + 1]);
                        }

                        if(isNextDigit)
                        {
                            carryValue = carryValue * 10 + value;
                        }
                        else
                        {
                            if(carryValue > 0)
                            {
                                carryValue = carryValue * 10 + value;
                                result = result + carryValue * lastOperator;
                                carryValue = 0;
                            }
                            else
                            {
                                result = result + value * lastOperator;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //string s = "(1+(4+5+2)-3)+(6+8)";
            //string s = " 2-1 + 2 ";
            //string s = "234455564";
            string s = "- (3 + (4 + 5))";
            //string s = "1-11";
            Solution sol = new Solution();
            Console.WriteLine(sol.Calculate(s));
            Console.ReadKey();
        }
    }
}

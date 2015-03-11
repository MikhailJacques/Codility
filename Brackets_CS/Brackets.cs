/* Brackets - Stacks and Queues

Determine whether a given string of parentheses is properly nested.

A string S consisting of N characters is considered to be properly nested if any of the following conditions is true:

- S is empty;
- S has the form "(U)" or "[U]" or "{U}" where U is a properly nested string;
- S has the form "VW" where V and W are properly nested strings.

For example, the string "{[()()]}" is properly nested but "([)()]" is not.

Write a function:

class Solution { public int solution(string S); }

that, given a string S consisting of N characters, returns 1 if S is properly nested and 0 otherwise.

For example:

- given S = "{[()()]}", the function should return 1
- given S = "([)()]", the function should return 0, as explained above.

Assume that:

- N is an integer within the range [0..200,000];
- string S consists only of the following characters: "(", "{", "[", "]", "}" and/or ")".

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(N) (not counting the storage required for input arguments).

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    public class Solution
    {
        // Algorithm
        //
        // Put every opening bracket on a stack. 
        // If a closing bracket is not the same as the top stack bracket, the string is not properly nested.

        // Scored 100% on www.codility.com
        public int Brackets(string S)
        {
            Dictionary<char, char> matched = new Dictionary<char, char>();
            matched.Add(']', '[');
            matched.Add('}', '{');
            matched.Add(')', '(');

            // Create and initialize a list of valid brackets
            List<char> pushElement = new List<char>();
            pushElement.Add('[');
            pushElement.Add('{');
            pushElement.Add('(');

            Stack<char> stack = new Stack<char>();

            foreach (char c in S)
            {
                // Check to see if c is an opening bracket
                if (pushElement.Contains(c))
                {
                    stack.Push(c);
                }
                else
                {
                    // Check to see if the stack is empty
                    if (stack.Count == 0)
                    {
                        return 0;
                    }
                    // Check to see if the top most element is NOT a matching closing bracket
                    else if (!stack.Pop().Equals(matched[c]))
                    {
                        return 0;
                    }
                }
            }

            // Check to see if the stack is empty
            if (stack.Count == 0)
            {
                return 1;
            }

            return 0;
        }

        // Scored 100% on www.codility.com
        public int Brackets2(string S)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var c in S )
            {
                if (c == '[' || c == '{' || c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return 0;
                    }
                    else if (  (c == ']' && stack.Peek() == '[') 
                            || (c == '}' && stack.Peek() == '{') 
                            || (c == ')' && stack.Peek() == '(') )
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            if (stack.Count == 0)
                return 1;
            else
                return 0;
        }
    }


    class MaxProductOfThree
    {
        static void Main(string[] args)
        {    
            string x = "{[()()]}(){}";              // Answer: 1

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.Brackets(x));
            Console.WriteLine("Solution: {0}", S.Brackets2(x));

            // Wait for user
            Console.ReadKey();
        }
    }
}
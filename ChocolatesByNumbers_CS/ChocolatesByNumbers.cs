/* ChocolatesByNumbers - Euclidean Algorithm

There are N chocolates in a circle. Count the number of chocolates you will eat.

Two positive integers N and M are given. 
Integer N represents the number of chocolates arranged in a circle, numbered from 0 to N − 1.

You start to eat the chocolates. After eating a chocolate you leave only a wrapper.

You begin with eating chocolate number 0. 
Then you omit the next M − 1 chocolates or wrappers on the circle, and eat the following one.

More precisely, if you ate chocolate number X, 
then you will next eat the chocolate with number (X + M) modulo N (remainder of division).

You stop eating when you encounter an empty wrapper.

For example, given integers N = 10 and M = 4. You will eat the following chocolates: 0, 4, 8, 2, 6.

The goal is to count the number of chocolates that you will eat, following the above rules.

Write a function:

class Solution { public int solution(int N, int M); }

that, given two positive integers N and M, returns the number of chocolates that you will eat.

For example, given integers N = 10 and M = 4. the function should return 5, as explained above.

Assume that:

- N and M are integers within the range [1..1,000,000,000].

Complexity:

- expected worst-case time complexity is O(log(N+M));
- expected worst-case space complexity is O(log(N+M)).

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolatesByNumbers
{
    public class Solution
    {
        // Algorithm
        //
        // N and M meet at their Least Common Multiply (LCM).
        // Dividing this LCM by M gets the number of steps (chocolates) that can be eaten.
        // For example, the LCM of 3 and 5 is 15 and the LCM of 10 and 4 is 20.
        //
        // The Greatest Common Divisor (GCD) of two or more integers, when at least one of them is not zero, 
        // is the largest positive integer that divides the numbers without a remainder. 
        // For example, the GCD of 8 and 12 is 4 and the GCD of 10 and 4 is 2.

        public int gcd(int a, int b)
        {
            if (a < b)
            {
                return gcd(b, a);
            }

            if (a % b == 0)
            {
                return b;
            }

            return gcd(b, a % b);
        }

        // Solution
        //
        // Scored 100% on www.codility.com
        public int ChocolatesByNumbers(int N, int M)
        {
            return N / gcd(N, M);
        }
    }

    class ChocolatesByNumbers
    {
        static void Main(string[] args)
        {
            int N = 10, M = 4;  // Answer: 5

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.ChocolatesByNumbers(N, M));

            // Wait for user
            Console.ReadKey();
        }
    }
}
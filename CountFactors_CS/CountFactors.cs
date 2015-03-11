/* CountFactors - Prime and composite numbers

Count factors of given number N.

A positive integer D is a factor of a positive integer N if there exists an integer M such that N = D * M.

For example, 6 is a factor of 24, because M = 4 satisfies the above condition (24 = 6 * 4).

Write a function:

class Solution { public int solution(int N); }

that, given a positive integer N, returns the number of its factors.

For example, given N = 24, the function should return 8, because 24 has 8 factors, namely 1, 2, 3, 4, 6, 8, 12, 24. 
There are no other factors of 24.

Assume that:

- N is an integer within the range [1..2,147,483,647].

 * Complexity:

- expected worst-case time complexity is O(sqrt(N));
- expected worst-case space complexity is O(1).

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountFactors
{
    public class Solution
    {
        // Algorithm
        //
        // CountFactors is a problem where one must compute the factors of a given number. 
        // We increment the count by two because based on one divisor, we can find the symmetric divisor. 
        // In other words, if A is a divisor of N then N/A is also one. 
        // The only case when that does not happen is when the number is in the form K^2, 
        // meaning that the symmetric divisor of K is also K.

        // Solution
        //
        // Scored 100% on www.codility.com
        public int CountFactors(int N)
        {
            int factor_candidate = 1, num_factors = 0;

            while (factor_candidate < Math.Sqrt(N))
            {
                // We increment the count by two because based on one divisor, we can find the symmetric divisor. 
                // In other words, if A is a divisor of N then N/A is also one. 
                if (N % factor_candidate == 0)
                    num_factors += 2;

                factor_candidate++;
            }

            // Check to see if there is a symmetric divisor of N of the form K^2.
            if (Math.Pow(factor_candidate, 2) == N)
                num_factors++;

            return num_factors;
        }
    }

    class CountFactors
    {
        static void Main(string[] args)
        {
            int N = 24;     // Answer: 8

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.CountFactors(N));

            // Wait for user
            Console.ReadKey();
        }
    }
}
/* MaxProfit - Maximum Slice Problem

Given a log of stock prices compute the maximum possible earning.

A zero-indexed array A consisting of N integers is given. 
It contains daily prices of a stock share for a period of N consecutive days. 
If a single share was bought on day P and sold on day Q, where 0 ≤ P ≤ Q < N, 
then the profit of such transaction is equal to A[Q] − A[P], provided that A[Q] ≥ A[P]. 
Otherwise, the transaction brings loss of A[P] − A[Q].

For example, consider the following array A consisting of six elements such that:

  A[0] = 23171  A[1] = 21011    A[2] = 21123    A[3] = 21366    A[4] = 21013    A[5] = 21367

If a share was bought on day 0 and sold on day 2, a loss of 2048 would occur because A[2] − A[0] = 21123 − 23171 = −2048. 

If a share was bought on day 4 and sold on day 5, a profit of 354 would occur because A[5] − A[4] = 21367 − 21013 = 354. 

Maximum possible profit was 356. It would occur if a share was bought on day 1 and sold on day 5.

Write a function,

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A consisting of N integers containing daily prices of a stock share for 
a period of N consecutive days, returns the maximum possible profit from one transaction during this period. 
The function should return 0 if it was impossible to gain any profit.

For example, given array A consisting of six elements such that:

  A[0] = 23171  A[1] = 21011    A[2] = 21123    A[3] = 21366    A[4] = 21013    A[5] = 21367

the function should return 356, as explained above.

Assume that:

- N is an integer within the range [0..400,000];
- each element of array A is an integer within the range [0..200,000].

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfit
{
    public class Solution
    {
        // Algorithm
        //
        // Keep the minimal value up to date. The profit on day i is profit[i] – min_profit.
        // Our goal is to basically compute the maximum profit that ends in a given position. 
        // Thus, if we assume that the maximum profit that ends in a position i equals maxProfit 
        // then the maximum slice ending in position i + 1 is going to be max(0, maxProfit + (ai - (ai - 1))).
        //

        // Solution
        //
        // Scored 100% on www.codility.com
        public int MaxProfit(int[] A)
        {
            if (A.Length == 0 || A.Length == 1)
                return 0;

            int max_profit = 0, max_slice = 0;

            for (int i = 1; i < A.Length; i++)
            {
                max_slice = Math.Max(0, max_slice + (A[i] - A[i - 1]));
                max_profit = Math.Max(max_profit, max_slice);
            }

            return max_profit;
        }

        // Solution
        //
        // Scored 100% on www.codility.com
        public int MaxProfit2(int[] A)
        {
            if (A.Length == 0 || A.Length == 1)
                return 0;

            int max_profit = 0, min_daily_price = 200000;

            foreach (var daily_price in A)
            {
                min_daily_price = Math.Min(daily_price, min_daily_price);
                max_profit = Math.Max(max_profit, daily_price - min_daily_price);
            }

            // Just another way for solving the problem. Same as above.
            int maxEndingHere = 0, minPrice = A[0], maxSoFar = 0;
            for (int i = 1; i < A.Length; i++)
            {
                maxEndingHere = Math.Max(0, A[i] - minPrice);
                minPrice = Math.Min(minPrice, A[i]);
                maxSoFar = Math.Max(maxEndingHere, maxSoFar);
            }
     
            return max_profit;
        }
    }

    class MaxProfit
    {
        static void Main(string[] args)
        {
            int[] x = { 23171, 21011, 21123, 21366, 21366, 21013, 21367 };  // Answer: 356

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.MaxProfit(x));
            Console.WriteLine("Solution: {0}", S.MaxProfit2(x));

            // Wait for user
            Console.ReadKey();
        }
    }
}
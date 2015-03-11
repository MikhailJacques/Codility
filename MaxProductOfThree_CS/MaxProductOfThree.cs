/* MaxProductOfThree - Sorting

A non-empty zero-indexed array A consisting of N integers is given.
The product of triplet (P, Q, R) equates to A[P] * A[Q] * A[R] (0 ≤ P < Q < R < N).
 
For example, array A such that:
 
  A[0] = -3     A[1] = 1    A[2] = 2    A[3] = -2   A[4] = 5    A[5] = 6
 
contains the following example triplets:

(0, 1, 2), product is −3 * 1 * 2 = −6
(1, 2, 4), product is 1 * 2 * 5 = 10
(2, 4, 5), product is 2 * 5 * 6 = 60
 
Your goal is to find the maximal product of any triplet.

Write a function:

class Solution { public int solution(int[] A); }

that, given a non-empty zero-indexed array A, returns the value of the maximal product of any triplet.

For example, given array A such that:

  A[0] = -3     A[1] = 1    A[2] = 2    A[3] = -2   A[4] = 5    A[5] = 6

the function should return 60, as the product of triplet (2, 4, 5) is maximal.

Assume that:

- N is an integer within the range [3..100,000];
- each element of array A is an integer within the range [−1,000..1,000].
 
Complexity:

- expected worst-case time complexity is O(N*log(N));
- expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).
 
Elements of input arrays can be modified.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProductOfThree
{
    public class Solution
    {
        // Scored 100% on www.codility.com
        public int MaxProductOfThree(int[] A)
        {
            int[] mins = { int.MaxValue, int.MaxValue };
            // Invariant: mins[0] <= mins[1]

            int[] maxes = {int.MinValue, int.MinValue, int.MinValue};
            // Invariant: maxes[0] <= maxes[1] <= maxes[2]
        
            // O(n)        
            foreach( int a in A )
            {
                updateMins(a, mins);
                updateMaxes(a, maxes);
            }

            int twoSmallestNegatives = mins[0] * mins[1] * maxes[2];
            int threeLargestPositives = maxes[0] * maxes[1] * maxes[2];

            return Math.Max(twoSmallestNegatives, threeLargestPositives);
        }

        private static void updateMins(int a, int[] mins)
        {
            if (a <= mins[0])
            {
                // Found new min, shift down
                mins[1] = mins[0];
                mins[0] = a;
            }
            else if (a < mins[1])
            {
                mins[1] = a;
            }
        }

        private static void updateMaxes(int a, int[] maxes)
        {
            if (a >= maxes[2])
            {
                // Found new max, shift down
                maxes[0] = maxes[1];
                maxes[1] = maxes[2];
                maxes[2] = a;
            }
            else if (a >= maxes[1])
            {
                maxes[0] = maxes[1];
                maxes[1] = a;
            }
            else if (a > maxes[0])
            {
                maxes[0] = a;
            }
        }
    }


    class MaxProductOfThree
    {
        static void Main(string[] args)
        {
            int[] x = { -3, 1, 2, -2, 5, 6 };       // Answer: 60
            // int[] x = { 10, 2, 5, 1, 8, 20 };	// Answer: 1600

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.MaxProductOfThree(x));

            // Wait for user
            Console.ReadKey();
        }
    }
}
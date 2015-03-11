/* Distinct - Sorting

Write a function

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A consisting of N integers, returns the number of distinct values in array A.

Assume that:

- N is an integer within the range [0..100,000];
- each element of array A is an integer within the range [−1,000,000..1,000,000].
 
For example, given array A consisting of six elements such that:

A[0] = 2    A[1] = 1    A[2] = 1    A[3] = 2    A[4] = 3    A[5] = 1

the function should return 3, because there are 3 distinct values appearing in array A, namely 1, 2 and 3.

Complexity:

- expected worst-case time complexity is O(N*log(N));
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distinct
{
    public class Solution
    {
        // Scored 100% on www.codility.com
        public int Distinct(int[] A)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (var i in A)     
                set.Add(i);

            return set.Count;
        }

        // Scored 83% on www.codility.com
        public int Distinct1(int[] A)
        {
            int [] TempIntArray = new int[A.Length];
            
            for (int i = 0; i < A.Length; i++)
                TempIntArray[i] = Math.Abs(A[i]);

            // var queryResults = from n in TempIntArray select n;
            // int  count = queryResults.Distinct().ToArray().Length;

            return (from n in TempIntArray select n).Distinct().ToArray().Length;
        }
    }

    class Distinct
    {
        static void Main(string[] args)
        {
            int [] x = { 2, 1, 1, 2, 3, 1 };	// Answer: 3

            Solution S = new Solution();

            // long solution = S.Distinct(x);

            Console.WriteLine("Solution: {0}", S.Distinct(x));
            Console.WriteLine("Solution: {0}", S.Distinct1(x));

            // Wait for user
            Console.ReadKey();
        }
    }
}
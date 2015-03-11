/* FrogRiverOne - Counting Elements

A small frog wants to get to the other side of a river.
The frog is currently located at position 0, and wants to get to position X. 
Leaves fall from a tree onto the surface of the river.

You are given a non-empty zero-indexed array A consisting of N integers representing the falling leaves. 
A[K] represents the position where one leaf falls at time K, measured in minutes.

The goal is to find the earliest time when the frog can jump to the other side of the river. 
The frog can cross only when leaves appear at every position across the river from 1 to X.

For example, you are given integer X = 5 and array A such that:

  A[0] = 1
  A[1] = 3
  A[2] = 1
  A[3] = 4
  A[4] = 2
  A[5] = 3
  A[6] = 5
  A[7] = 4
 
In minute 6, a leaf falls into position 5. This is the earliest time when leaves appear in every position across the river.

Write a function:

class Solution { public int solution(int X, int[] A); }

that, given a non-empty zero-indexed array A consisting of N integers and integer X, 
returns the earliest time when the frog can jump to the other side of the river.

If the frog is never able to jump to the other side of the river, the function should return −1.

For example, given X = 5 and array A such that:

  A[0] = 1
  A[1] = 3
  A[2] = 1
  A[3] = 4
  A[4] = 2
  A[5] = 3
  A[6] = 5
  A[7] = 4

the function should return 6, as explained above.

Assume that:

- N and X are integers within the range [1..100,000];
- each element of array A is an integer within the range [1..X].
 
Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(X), beyond input storage (not counting the storage required for input arguments).
 
Elements of input arrays can be modified.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogRiverOne
{
    public class Solution
    {
        // Scored 90% on www.codility.com
        // Finds the earliest time when a frog can jump to the other side of a river.
        public int FrogRiverOne(int X, int[] A)
        {
            bool [] seen = new bool[A.Length];

	        // When reach X the frog has all the leaves
	        int ready = 0;

	        for (int i = 0; i < A.Length; i++)
	        {
		        if (A[i] <= X && (seen[A[i] - 1] == false))
		        {
			        seen[A[i] - 1] = true;

			        ready++;

			        if (ready == X)
				        return i;
		        }
	        }

	        return -1;
        }
    }

    class FrogRiverOne
    {
        static void Main(string[] args)
        {
            // int [] x = { 1, 3, 1, 4, 2, 3, 5, 4 };	// Answer: 6
	        int [] x = { 4, 1, 1, 2, 1, 3, 1, 5, 3 };	// Answer: 7

            Solution S = new Solution();

            int solution = S.FrogRiverOne(5, x);

            Console.WriteLine("Solution: {0}", solution);

            // Wait for user
            Console.ReadKey();
        }
    }
}
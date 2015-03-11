/* Triangle - Sorting

Determine whether a triangle can be built from a given set of edges.

A zero-indexed array A consisting of N integers is given. 

A triplet (P, Q, R) is triangular if 0 ≤ P < Q < R < N and:

A[P] + A[Q] > A[R],
A[Q] + A[R] > A[P],
A[R] + A[P] > A[Q].

For example, consider array A such that:

  A[0] = 10    A[1] = 2    A[2] = 5
  A[3] = 1     A[4] = 8    A[5] = 20

Triplet of indices (0, 2, 4) with the corresponding values (10, 5, 8) is triangular.

Write a function:

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A consisting of N integers, 
returns 1 if there exists a triangular triplet for this array and returns 0 otherwise.

For example:

Given array A such that:

  A[0] = 10    A[1] = 2    A[2] = 5     A[3] = 1     A[4] = 8    A[5] = 20
 
the function should return 1, as explained above. 

Given array A such that:

  A[0] = 10    A[1] = 50    A[2] = 5    A[3] = 1
 
the function should return 0.

Assume that:

- N is an integer within the range [0..100,000];
- each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

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

namespace Triangle
{
    public class Solution
    {
        // Algorithm
        //
        // Sort the elements of the array. 
        // Note that there is no limitation on sorting since sorting is good for meeting the time complexity requirement.
        // In addition, 3 numbers are triangular if and only if:
        // A + B > C
        // A + C > B
        // B + C > A
        // For simplification, assume A, B, C are greater than 0.
        // After sorting, with any three consecutive (non-decreasing) integers A, B, C, we already know:
        // A + C > B
        // B + C > A
        // Then, we only need to check A + B and C.

        // Solution
        //
        // Scored 100% on www.codility.com
        // Checks whether there is a triangular triplet
        // @param A: The array with elements representing lengths of lines
        // @return: 1 - triangular triplet is found
        //          0 - no triangular triplet is found        
        public int Triangle(int[] A)
        { 
            // Handle the special cases
            if (A == null || A.Length < 3) 
                return 0;

            // Sort the input, and then try to find the triangle
            Array.Sort(A);

            for (int i = 0; i < A.Length - 2; i++)
            {
                // Beware of overflow - subtract as opposed to add to prevent overflow.
                if (A[i] >= 0 && (A[i] > A[i + 2] - A[i + 1]))
                {
                    return 1;
                }

                // We already know that A[i+1] <= A[i+2]. 
                // If A[i] < 0 => A[i] + A[i+1] < A[i+2]
            }

            return 0;
        }
    }

    class Triangle
    {
        static void Main(string[] args)
        {
	        int [] x1 = { 10, 2, 5, 1, 8, 20 };	    // Answer: 1
            int [] x0 = { 10, 50, 5, 1 };           // Answer: 0

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.Triangle(x1));
            Console.WriteLine("Solution: {0}", S.Triangle(x0));

            // Wait for user
            Console.ReadKey();
        }
    }
}
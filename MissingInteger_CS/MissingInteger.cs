/* MissingInteger - Counting Elements

Write a function:

class Solution { public int solution(int[] A); }

that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer that does not occur in A.

For example, given:

  A[0] = 1
  A[1] = 3
  A[2] = 6
  A[3] = 4
  A[4] = 1
  A[5] = 2
 
the function should return 5.

Assume that:

- N is an integer within the range [1..100,000];
- each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
 
Elements of input arrays can be modified.

 */

// https://codility.com/c/intro/demoQ73C4A-E3S

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingInteger
{
    public class Solution
    {
        // Scored 100% on www.codility.com
        public int MissingInteger(int[] A)
        {
	        // If there is no positive integer lacking between 1 and N, the answer should be N + 1.
	        int i, N = A.Length, ans = N + 1;

	        // Prepare the flags
	        int [] flag = new int[N];

	        // Set memory to zeros
	        for (i = 0; i < N; i++)
		        flag[i] = 0;

	        // Iterate over the given array A
	        for (i = 0; i < N; i++)
	        {
		        // We can neglect the value below 1 or larger than N.
		        if (A[i] <= 0 || A[i] > N)
		        {
			        continue;
		        }

		        // Turn on the flag. This is a zero-indexed array so give -1 is the offset.
		        flag[A[i] - 1] = 1; 
	        }

	        // Attempt to find the minimum positive integer that is not found in the array A.
	        for (i = 0; i < N; i++)
	        {
		        if (flag[i] == 0)
		        {
			        // The answer is (the index + 1). (we have -1 offset).
			        ans = i + 1; 

			        break; // Found the first minimal positive integer
		        }
	        }

	        return ans;
        }
    }

    class MissingInteger
    {
        static void Main(string[] args)
        {
            int [] x = { 1, 3, 6, 4, 1, 2 };

            Solution S = new Solution();

            int solution = S.MissingInteger(x);

            Console.WriteLine("Solution: {0}", solution);

            // Wait for user
            Console.ReadKey();
        }
    }
}
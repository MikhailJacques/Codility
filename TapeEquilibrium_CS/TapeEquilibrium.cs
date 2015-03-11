/* TapeEquilibrium - Time Complexity

A non-empty zero-indexed array A consisting of N integers is given. Array A represents numbers on a tape.

Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].

The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|

In other words, it is the absolute difference between the sum of the first part and the sum of the second part.

For example, consider array A such that:

A[0] = 3
A[1] = 1
A[2] = 2
A[3] = 4
A[4] = 3
 * 
We can split this tape in four places:

P = 1, difference = |3 − 10| = 7
P = 2, difference = |4 − 9| = 5
P = 3, difference = |6 − 7| = 1
P = 4, difference = |10 − 3| = 7
 
Write a function:

int solution(int A[], int N);

that, given a non-empty zero-indexed array A of N integers, returns the minimal difference that can be achieved.

For example, given:

A[0] = 3
A[1] = 1
A[2] = 2
A[3] = 4
A[4] = 3
 
the function should return 1, as explained above.

Assume that:

N is an integer within the range [2..100,000];
 
each element of array A is an integer within the range [−1,000..1,000].
 
Complexity:

expected worst-case time complexity is O(N);
expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
 
Elements of input arrays can be modified.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapeEquilibrium
{
    class Solution1
    {
        public long TapeEquilibrium(int[] A)
        {
            // write your code in C# with .NET 2.0
            long currentP, diff, min = long.MaxValue, sumLeft = 0, sumRight = 0;

            for (int i = 0; i < A.Length; i++)
                sumRight += A[i];

            for (int P = 1; P < A.Length; P++)
            {
                currentP = A[P-1];
                sumLeft += currentP;
                sumRight -= currentP;

                diff = Math.Abs(sumLeft - sumRight);
                min = Math.Min(diff, min);
            }

            return min;
        }
    }

    class TapeEquilibrium
    {
        static void Main(string[] args)
        {
            // int [] x = { 3, 1, 2, 4, 3 };    // Answer: 1
	        // int [] x = { 5, 1, 2, 4, 3, 1 }; // Answer: 0
	        int [] x = {3, 1, 2, 4, 3, 1};     // Answer: 2

            Solution1 S1 = new Solution1();

            long solution = S1.TapeEquilibrium(x);

            Console.WriteLine("Solution: {0}", solution);

            // Wait for user
            Console.ReadKey();
        }
    }
}

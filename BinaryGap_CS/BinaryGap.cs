/* BinaryGap - Future Training

Find longest sequence of zeros in binary representation of an integer.

A binary gap within a positive integer N is any maximal sequence of consecutive zeros 
 * that is surrounded by ones at both ends in the binary representation of N.

For example, number 9 has binary representation 1001 and contains a binary gap of length 2. 
The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3. 
The number 20 has binary representation 10100 and contains one binary gap of length 1. 
The number 15 has binary representation 1111 and has no binary gaps.

Write a function:

class Solution { public int solution(int N); }

that, given a positive integer N, returns the length of its longest binary gap. 
The function should return 0 if N doesn't contain a binary gap.

For example, given N = 1041 the function should return 5, 
because N has binary representation 10000010001 and so its longest binary gap is of length 5.

Assume that:

- N is an integer within the range [1..2,147,483,647].

Complexity:

- expected worst-case time complexity is O(log(N));
- expected worst-case space complexity is O(1).

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryGap
{
    public class Solution
    {
        // Algorithm
        //
     
        // Solution
        //
        // Scored 100% on www.codility.com
        public int BinaryGap(int N)
        {
		    int max = 0, r = 0, count = -1;
 
		    while (N > 0) 
            {
			    // Get right most bit & shift right
			    r = N & 1;
			    N = N >> 1;
 
			    if (r == 0 && count >= 0) 
                {
				    count++;
			    }
 
			    if (r == 1) 
                {
				    max = count > max ? count : max;
				    count = 0;
			    }
		    }
 
		    return max;
	    }
    }

    class BinaryGap
    {
        static void Main(string[] args)
        {
            int N = 1041;   // Answer: 5

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.BinaryGap(N));

            // Wait for user
            Console.ReadKey();
        }
    }
}
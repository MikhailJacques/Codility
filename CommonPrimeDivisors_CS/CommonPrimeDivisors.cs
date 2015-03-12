/* CommonPrimeDivisors - Euclidean Algorithm

Check whether two numbers have the same prime divisors.

A prime is a positive integer X that has exactly two distinct divisors: 1 and X. 
The first few prime integers are 2, 3, 5, 7, 11 and 13.

A prime D is called a prime divisor of a positive integer P if there exists a positive integer K such that D * K = P. 
For example, 2 and 5 are prime divisors of 20.

You are given two positive integers N and M.
The goal is to check whether the sets of prime divisors of integers N and M are exactly the same.

For example, given:

- N = 15 and M = 75, the prime divisors are the same: {3, 5};
- N = 10 and M = 30, the prime divisors aren't the same: {2, 5} is not equal to {2, 3, 5};
- N = 9 and M = 5, the prime divisors aren't the same: {3} is not equal to {5}.

Write a function:

class Solution { public int solution(int[] A, int[] B); }

that, given two non-empty zero-indexed arrays A and B of Z integers, 
returns the number of positions K for which the prime divisors of A[K] and B[K] are exactly the same.

For example, given:

    A[0] = 15   B[0] = 75
    A[1] = 10   B[1] = 30
    A[2] = 3    B[2] = 5

the function should return 1, because only one pair (15, 75) has the same set of prime divisors.

Assume that:

- Z is an integer within the range [1..6,000];
- each element of arrays A, B is an integer within the range [1..2,147,483,647].

Complexity:

- expected worst-case time complexity is O(Z * log(max(A) + max(B))2);
- expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified. 

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPrimeDivisors
{
    public class Solution
    {
        // Algorithm
        //

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

        public bool isCommon(int a, int b) 
        {
	        int gcdA, gcdB;
	        int gcdValue = gcd(a, b);
	
	        while (a != 1) 
	        {
		        gcdA = gcd(a, gcdValue);

		        if (gcdA == 1)
			        break;

		        a = a / gcdA;
	        }

	        if (a != 1)  
	        {
		        return false;
	        }

	        while (b != 1) 
	        {
		        gcdB = gcd(b, gcdValue);

		        if (gcdB == 1)
			        break;

		        b = b / gcdB;
	        }

	        return b == 1;
        }

        // Solution
        //
        // Scored 100% on www.codility.com
        public int CommonPrimeDivisors(int [] A, int [] B)
        {
	        int result = 0;

	        for (int i = 0; i < A.Length; i++) 
	        {
		        if (isCommon(A[i], B[i])) 
		        {
			        result++;
		        }
	        }

	        return result;
        }
    }

    class CommonPrimeDivisors
    {
        static void Main(string[] args)
        {
            int [] A = { 15, 10, 3 };		// Answer: 1	 
	        int [] B = { 75, 30, 5 };

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.CommonPrimeDivisors(A, B));

            // Wait for user
            Console.ReadKey();
        }
    }
}
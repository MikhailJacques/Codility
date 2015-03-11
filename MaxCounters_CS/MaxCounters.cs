﻿/* MaxCounters - Counting Elements

You are given N counters, initially set to 0, and you have two possible operations on them:

increase(X) − counter X is increased by 1,
max counter − all counters are set to the maximum value of any counter.

A non-empty zero-indexed array A of M integers is given. This array represents consecutive operations:

- if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
- if A[K] = N + 1 then operation K is max counter.

For example, given integer N = 5 and array A such that:

    A[0] = 3
    A[1] = 4
    A[2] = 4
    A[3] = 6
    A[4] = 1
    A[5] = 4
    A[6] = 4

the values of the counters after each consecutive operation will be:

    (0, 0, 1, 0, 0)
    (0, 0, 1, 1, 0)
    (0, 0, 1, 2, 0)
    (2, 2, 2, 2, 2)
    (3, 2, 2, 2, 2)
    (3, 2, 2, 3, 2)
    (3, 2, 2, 4, 2)

The goal is to calculate the value of every counter after all operations.

Write a function:

class Solution { public int[] solution(int N, int[] A); }

that, given an integer N and a non-empty zero-indexed array A consisting of M integers, returns a sequence of integers representing the values of the counters.

The sequence should be returned as:

- a structure Results (in C), or
- a vector of integers (in C++), or
- a record Results (in Pascal), or
- an array of integers (in any other programming language).

For example, given:

    A[0] = 3
    A[1] = 4
    A[2] = 4
    A[3] = 6
    A[4] = 1
    A[5] = 4
    A[6] = 4

the function should return [3, 2, 2, 4, 2], as explained above.

Assume that:

N and M are integers within the range [1..100,000];
each element of array A is an integer within the range [1..N + 1].

Complexity:

- expected worst-case time complexity is O(N+M);
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCounters
{
    public class Solution
    {
        // Scored 100% on www.codility.com
        // Calculates the values of counters after applying all alternating operations: 
        // increase counter by 1; set value of all counters to current maximum.
        // Input parms:	
        // - N counters
        // - A non-empty zero-indexed array A of M integers representing consecutive operations
        public int[] MaxCounters(int N, int[] A)
        {
            int[] sol = new int[N];

            int current_max = 0, last_increase = 0;

            // Set the N counters to 0            
            for (int i = 0; i < N; i++)
                sol[i] = 0;

            // if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
            // if A[K] = N + 1 then operation K is max counter.
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N) // A[K] = N + 1
                {
                    last_increase = current_max;
                }
                else // A[K] = X, such that 1 ≤ X ≤ N,
                {
                    sol[A[i] - 1] = Math.Max(sol[A[i] - 1], last_increase);
                    sol[A[i] - 1]++;
                    current_max = Math.Max(current_max, sol[A[i] - 1]);
                }
            }

            for (int i = 0; i < N; i++)
                sol[i] = Math.Max(sol[i], last_increase);

            return sol;
        }
    }

    class MaxCounters
    {
        static void Main(string[] args)
        {
            int [] x = { 3, 4, 4, 6, 1, 4, 4 };

            Solution S = new Solution();

            int [] counters = S.MaxCounters(5, x);

            Console.Write("(");
            for (int i = 0; i < counters.Length; i++)
                Console.Write("{0},", counters[i]);
            Console.Write(")");

            // Wait for user
            Console.ReadKey();
        }
    }
}
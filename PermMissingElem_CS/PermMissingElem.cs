﻿/* PermMissingElem - Time Complexity

A zero-indexed array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], 
which means that exactly one element is missing.

Your goal is to find that missing element.

Write a function:

int solution(int A[], int N);

that, given a zero-indexed array A, returns the value of the missing element.

For example, given array A such that:

  A[0] = 2
  A[1] = 3
  A[2] = 1
  A[3] = 5

the function should return 4, as it is the missing element.

Assume that:

- N is an integer within the range [0..100,000];
- the elements of A are all distinct;
- each element of array A is an integer within the range [1..(N + 1)].

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

namespace PermMissingElem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 1, 2, 3, 5 };  // Answer: 4

            Solution S = new Solution();

            int solution = S.PermMissingElem(x);

            Console.WriteLine("Solution: {0}", solution);

            // Wait for user
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int PermMissingElem(int[] A)
        {
            long N = A.Length + 1;

            long total = N * (N + 1) / 2;

            foreach (int i in A)
                total -= i;

            return (int)total;
        }
    }
}
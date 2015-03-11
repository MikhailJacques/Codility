﻿/* MinPerimeterRectangle - Prime and composite numbers

Find the minimal perimeter of any rectangle whose area equals N.

An integer N is given, representing the area of some rectangle.

The area of a rectangle whose sides are of length A and B is A * B, and the perimeter is 2 * (A + B).

The goal is to find the minimal perimeter of any rectangle whose area equals N. 
The sides of this rectangle should be only integers.

For example, given integer N = 30, rectangles of area 30 are:

(1, 30), with a perimeter of 62,
(2, 15), with a perimeter of 34,
(3, 10), with a perimeter of 26,
(5, 6), with a perimeter of 22.

Write a function:

class Solution { public int solution(int N); }

that, given an integer N, returns the minimal perimeter of any rectangle whose area is exactly equal to N.

For example, given an integer N = 30, the function should return 22, as explained above.

Assume that:

- N is an integer within the range [1..1,000,000,000].

Complexity:

- expected worst-case time complexity is O(sqrt(N));
- expected worst-case space complexity is O(1).

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPerimeterRectangle
{
    public class Solution
    {
        // Algorithm
        //
        // Let the length of one side be len_1, and the length of one adjacent side be len_2. 
        // For a rectangle with a constant area, the perimeter is minimized when the difference 
        // between len_1 and len_2, abs(len_1 - len_2), is minimized.

        // Solution
        //
        // Scored 100% on www.codility.com
        public int MinPerimeterRectangle(int N)
        {
            int minPer = int.MaxValue;

            for (int i = 1; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    // Area = A * B
                    // Perimeter = 2 * (A + B)
                    minPer = Math.Min(minPer, 2 * (N / i + i));
                }
            }

            return minPer;
        }
    }

    class MinPerimeterRectangle
    {
        static void Main(string[] args)
        {
            int N = 30;     // Answer: 22

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.MinPerimeterRectangle(N));

            // Wait for user
            Console.ReadKey();
        }
    }
}
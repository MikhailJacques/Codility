/* Dominator - Leader

Find an index of an array such that its value occurs at more than half of indices in the array.

A zero-indexed array A consisting of N integers is given. 
The dominator of array A is the value that occurs in more than half of the elements of A.

For example, consider array A such that

A[0] = 3    A[1] = 4    A[2] =  3   A[3] = 2    A[4] = 3    A[5] = -1   A[6] = 3    A[7] = 3

The dominator of A is 3 because it occurs in 5 out of 8 elements of A, 
namely in those with indices 0, 2, 4, 6 and 7 and 5 is more than a half of 8.

Write a function

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A consisting of N integers, returns index of any element of array A 
in which the dominator of A occurs. The function should return −1 if array A does not have a dominator.

Assume that:

- N is an integer within the range [0..100,000];
- each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

For example, given array A such that

A[0] = 3    A[1] = 4    A[2] =  3   A[3] = 2    A[4] = 3    A[5] = -1   A[6] = 3    A[7] = 3

the function may return 0, 2, 4, 6 or 7, as explained above.

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

namespace Dominator
{
    public class Solution
    {
        // Algorithm
        //
        // Notice that if the sequence a0, a1, . . . , an−1 contains a leader, 
        // then after removing a pair of elements of different values, the remaining sequence still has the same leader. 
        // Indeed, if we remove two different elements then only one of them could be the leader. 
        // The leader in the new sequence occurs more than n/2−1 = (n−2)/2 times. 
        // Consequently, it is still the leader of the new sequence of n−2 elements.
        //
        // Removing pairs of different elements is not trivial.
        // We create a hypothetical empty stack onto which we will be pushing consecutive elements. 
        // After each such operation we check whether the two elements at the top of the stack are different. 
        // If they are, we conceptually remove them from the hypothetical stack.
        // This is equivalent to removing a pair of different elements from the sequence.
        //
        // In fact, we don’t need to remember all the elements from the stack, 
        // because all the values below the top are always equal. 
        // It is sufficient to remember only the values of elements and the size of the stack.
        //
        // At the beginning we notice that if the sequence contains a leader, 
        // then after the removal of different elements the leader will not have changed. 
        // After removing all pairs of different elements, we end up with a sequence containing all the same values. 
        // This value is not necessarily the leader. It is only a candidate for the leader.
        //
        // Finally, we iterate through all the elements and count the occurrences of the candidate.
        // If the number of occurrences is greater than n/2 then we have found the leader; 
        // otherwise, the sequence does not contain a leader.
        //
        // The time complexity of this algorithm is O(n) because every element is considered only once. 
        // The final counting of occurrences of the candidate value also works in O(n) time.

        // Solution
        //
        // Scored 100% on www.codility.com
        public int Dominator(int[] A)
        {
            int count = 0, candidate = -1, candidate_count = 0, candidate_index = -1;

            for (int i = 0; i < A.Length; i++)
            {
                if (candidate_count == 0)
                {
                    candidate = A[i];
                    candidate_index = i;
                    candidate_count += 1;
                }
                else
                {
                    if (A[i] == candidate)
                        candidate_count += 1;
                    else
                        candidate_count -= 1;
                }
            }

            //  Iterate through all the elements and count the occurrences of the candidate.
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    // If the number of occurrences is greater than n/2 then we have found the leader.
                    if (++count > A.Length / 2)
                        return candidate_index; // Index of the dominator (leader) was found
                }
            }

            return -1;                          // Index of the dominator (leader) was NOT found
        }
  
        // Algorithm
        //
        // If the sequence is presented in non-decreasing order, then identical values are adjacent to each other.
        // Having sorted the sequence, we can easily count slices of the same values and find the leader in a smarter way. 
        // Notice that if the leader occurs somewhere in our sequence, then it must occur at index n/2 (the central element).
        // This is because, given that the leader occurs in more than half the total values in the sequence, 
        // there are more leader values than will fit on either side of the central element in the sequence.

        // Solution
        //
        // Scored 58% on www.codility.com
        public int Dominator2(int[] A)
        {
            int count = 0, leader = -1;

            int[] B = new int [A.Length];
            for (int i = 0; i < A.Length; i++)
                B[i] = A[i];

            Array.Sort(A);

            int candidate = A[A.Length / 2];

            for (int i = 0; i < A.Length; i++)
            {
                if (++count > A.Length / 2)
                {
                    leader = candidate; // Found the value of the dominator (leader)
                    break;
                }
            }

            for (int i = 0; i < B.Length; i++)
                if (B[i] == leader)
                    return i;           // Found the first index of the dominator (leader)

            return leader;
        }
    }

    class Dominator
    {
        static void Main(string[] args)
        {
            int[] x = { 3, 4, 3, 2, 3, -1, 3, 3 };       // Answer: 6

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.Dominator(x));     // Answer: 6
            Console.WriteLine("Solution: {0}", S.Dominator2(x));    // Answer: 0

            // Wait for user
            Console.ReadKey();
        }
    }
}
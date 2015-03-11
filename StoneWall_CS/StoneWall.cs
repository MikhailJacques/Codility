/* StoneWall - Stacks and Queues

Cover "Manhattan skyline" using the minimum number of rectangles.

Solution to this task can be found at our blog.

You are going to build a stone wall. 
The wall should be straight and N meters long, and its thickness should be constant.
However, it should have different heights in different places. 
The height of the wall is specified by a zero-indexed array H of N positive integers. 
H[I] is the height of the wall from I to I+1 meters to the right of its left end. 
In particular, H[0] is the height of the wall's left end and H[N−1] is the height of the wall's right end.

The wall should be built of cuboid stone blocks (that is, all sides of such blocks are rectangular). 
Your task is to compute the minimum number of blocks needed to build the wall.

Write a function:

class Solution { public int solution(int[] H); }

that, given a zero-indexed array H of N positive integers specifying the height of the wall, 
returns the minimum number of blocks needed to build it.

For example, given array H containing N = 9 integers:

  H[0] = 8    H[1] = 8    H[2] = 5
  H[3] = 7    H[4] = 9    H[5] = 8
  H[6] = 7    H[7] = 4    H[8] = 8

the function should return 7. The figure shows one possible arrangement of seven blocks.

Assume that:

- N is an integer within the range [1..100,000];
- each element of array H is an integer within the range [1..1,000,000,000].

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

// http://codesays.com/2014/solution-to-sigma-2012-stone-wall-by-codility/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWall
{
    public class Solution
    {
        // Algorithm
        //
        // http://blog.codility.com/2012/06/sigma-2012-codility-programming.html

        // Scored 100% on www.codility.com
        public int StoneWall(int[] H)
        {
            int Blocks = 0;
            Stack<int> StoneDetails = new Stack<int>();

            for (int i = 0; i < H.Length; i++)
            {
                if (!IsStoneExists(H[i], StoneDetails))
                    Blocks++;
            }

            return Blocks;
        }

        private bool IsStoneExists(int CurHeight, Stack<int> StoneDetails)
        {
            bool StoneExists = false;

            while (StoneDetails.Count != 0)
            {
                int PeekedElement = StoneDetails.Peek();

                if (PeekedElement == CurHeight)
                {
                    StoneExists = true;
                    break;
                }
                else if (PeekedElement < CurHeight)
                {
                    StoneExists = false;
                    break;
                }
                else if (PeekedElement > CurHeight)
                {
                    StoneDetails.Pop();
                }
            }

            if (!StoneExists)
                StoneDetails.Push(CurHeight);

            return StoneExists;
        }

        // Scored 100% on www.codility.com
        public int StoneWall1(int[] H)
        {
            // The number of needing blocks
            int block_count = 0; 
            Stack<int> stack = new Stack<int>();
 
            foreach (var height in H)
            {
                while (stack.Count != 0 && height < stack.Peek())  // stack[-1]
                {
                    // If the height of current block is less than height of the previous ones, 
                    // the previous ones have to end before the current point. 
                    // They have no chance to exist in the remaining part. 
                    // So the previous blocks are completely finished.
                    stack.Pop();

                    block_count += 1;
                }

                if (stack.Count == 0 || height > stack.Peek()) // stack[-1]
                {
                    // If the height of the current block is greater than the height of the previous one, 
                    // a new block is needed for current position.
                    stack.Push(height);
                }
                // else (the height of current block is same as that 
                // of previous one), they should be combined to one block.
            }
 
            // Some blocks with different heights are still in the stack.
            block_count += stack.Count;

            return block_count;
        }

        public int StoneWall2(int[] H)
        {
            int neededBlocks = 1;
            // https://msdn.microsoft.com/en-us/library/he2s3bh7(v=vs.110).aspx
            LinkedList<int> blocks = new LinkedList<int>();
            blocks.AddFirst(H[0]);

            int height = H[0];

            for (int i = 1; i < H.Length; i++)
            {
                while (H[i] < height)
                {
                    int last = blocks.Last();
                    blocks.RemoveLast(); 
                    height -= last;
                }

                if (H[i] > height)
                {
                    blocks.AddFirst(H[i] - height);
                    height = H[i];
                    neededBlocks++;
                }
            }

            return neededBlocks;
        }
    }


    class StoneWall
    {
        static void Main(string[] args)
        {    
            int [] x = {8, 8, 5, 7, 9, 8, 7, 4, 8};       // Answer: 7

            Solution S = new Solution();

            Console.WriteLine("Solution: {0}", S.StoneWall(x));
            Console.WriteLine("Solution: {0}", S.StoneWall1(x));
            Console.WriteLine("Solution: {0}", S.StoneWall2(x));

            // Wait for user
            Console.ReadKey();
        }
    }
}
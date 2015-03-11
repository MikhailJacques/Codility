/* MaxProductOfThree - Sorting

A non-empty zero-indexed array A consisting of N integers is given. 

The product of triplet (P, Q, R) equates to A[P] * A[Q] * A[R] (0 ≤ P < Q < R < N).

For example, array A such that:

	A[0] = -3	A[1] = 1	A[2] = 2	A[3] = -2	A[4] = 5	A[5] = 6

contains the following example triplets:

(0, 1, 2), product is −3 * 1 * 2 = −6
(1, 2, 4), product is 1 * 2 * 5 = 10
(2, 4, 5), product is 2 * 5 * 6 = 60

Your goal is to find the maximal product of any triplet.

Write a function:

int solution(vector<int> &A);

that, given a non-empty zero-indexed array A, returns the value of the maximal product of any triplet.

For example, given array A such that:

	A[0] = -3	A[1] = 1	A[2] = 2	A[3] = -2	A[4] = 5	A[5] = 6

the function should return 60, as the product of triplet (2, 4, 5) is maximal.

Assume that:

- N is an integer within the range [3..100,000];
- each element of array A is an integer within the range [−1,000..1,000].

Complexity:

- expected worst-case time complexity is O(N*log(N));
- expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <limits>		// std::numeric_limits<int>::min() AND std::numeric_limits<int>::max()
#include <vector>
#include <iostream>
#include <algorithm>	// std::max

using namespace std;

void updateMins(int a, int mins[]);
void updateMaxes(int a, int maxes[]);

// Scored 100% on www.codility.com 
int MaxProductOfThree(vector<int> &A)
{
	int mins[2] = {	numeric_limits<int>::max(), numeric_limits<int>::max() };
	// Invariant: mins[0] <= mins[1]

	int maxes[3] = { numeric_limits<int>::min(), numeric_limits<int>::min(), numeric_limits<int>::min() };
	// Invariant: maxes[0] <= maxes[1] <= maxes[2]

	// O(n)        
	for (unsigned i = 0; i < A.size(); i++)
	{
		updateMins(A[i], mins);
		updateMaxes(A[i], maxes);
	}

	int twoSmallestNegatives = mins[0] * mins[1] * maxes[2];
	int threeLargestPositives = maxes[0] * maxes[1] * maxes[2];

	return max(twoSmallestNegatives, threeLargestPositives);
}

void updateMins(int a, int mins[])
{
	if (a <= mins[0])
	{
		// Found new min, shift down
		mins[1] = mins[0];
		mins[0] = a;
	}
	else if (a < mins[1])
	{
		mins[1] = a;
	}
}

void updateMaxes(int a, int maxes[])
{
	if (a >= maxes[2])
	{
		// Found new max, shift down
		maxes[0] = maxes[1];
		maxes[1] = maxes[2];
		maxes[2] = a;
	}
	else if (a >= maxes[1])
	{
		maxes[0] = maxes[1];
		maxes[1] = a;
	}
	else if (a > maxes[0])
	{
		maxes[0] = a;
	}
}


int main()
{
	int x[6] = { -3, 1, 2, -2, 5, 6 };       // Answer: 60

	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << MaxProductOfThree(v) << endl;

	cin.get();

	return 0;
}
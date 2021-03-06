﻿/* MaxSliceSum - Maximum Slice Problem

Find a maximum sum of a compact subsequence of array elements. The classic maximum subarray problem.

A non-empty zero-indexed array A consisting of N integers is given. 
A pair of integers (P, Q), such that 0 ≤ P ≤ Q < N, is called a slice of array A. 
The sum of a slice (P, Q) is the total of A[P] + A[P+1] + ... + A[Q].

Write a function:

int solution(vector<int> &A);

that, given an array A consisting of N integers, returns the maximum sum of any slice of A.

For example, given array A such that:

A[0] = 3	A[1] = 2	A[2] = -6	A[3] = 4	A[4] = 0

the function should return 5 because:

- (3, 4) is a slice of A that has sum 4,
- (2, 2) is a slice of A that has sum −6,
- (0, 1) is a slice of A that has sum 5,

no other slice of A has sum greater than (0, 1).

Assume that:

- N is an integer within the range [1..1,000,000];
- each element of array A is an integer within the range [−1,000,000..1,000,000];
- the result will be an integer within the range [−2,147,483,648..2,147,483,647].

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <stack>
#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

// Algorithm
//

// Solution
//
// Scored 100% on www.codility.com
int MaxSliceSum(vector<int> &A)
{
	if (A.size() == 0)
		return 0;

	int maxSoFar = A[0];
	int maxEndingHere = A[0];

	for (unsigned i = 1; i < A.size(); i++)
	{
		maxEndingHere = std::max(A[i], maxEndingHere + A[i]);
		maxSoFar = std::max(maxSoFar, maxEndingHere);
	}

	return maxSoFar;
}

int main()
{
	int x[7] = { 3, 2, -6, 4, 0 };  // Answer: 5

	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << MaxSliceSum(v) << endl;

	cin.get();

	return 0;
}
/* Distinct - Sorting

Write a function

int solution(vector<int> &A);

that, given a zero-indexed array A consisting of N integers, returns the number of distinct values in array A.

Assume that:

- N is an integer within the range [0..100,000];
- each element of array A is an integer within the range [−1,000,000..1,000,000].

For example, given array A consisting of six elements such that:

A[0] = 2    A[1] = 1    A[2] = 1	A[3] = 2    A[4] = 3    A[5] = 1

the function should return 3, because there are 3 distinct values appearing in array A, namely 1, 2 and 3.

Complexity:

- expected worst-case time complexity is O(N*log(N));
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <set>
#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

// Scored 100% on www.codility.com
int Distinct(vector<int> &A)
{
	// The std set is a Red-Black Tree and therefore has insertion complexity of log N. (overall N log N)
	std::set<int> distinct;

	for (unsigned i = 0; i < A.size(); i++)
		distinct.insert(A[i]);

	return distinct.size();
}

// Scored 83% on www.codility.com
int Distinct1(vector<int> &A) 
{
	if (A.size() <= 0)
		return 0;

	// Always count the first number
	int count = 1;

	// Make a copy and calculate absolute values of all items
	vector<int> B = vector<int>(A);

	for (unsigned i = 0; i < A.size(); i++)
		A[i] = abs(A[i]);

	// Sort in order to have a simple absolute count
	sort(A.begin(), A.end());

	for (unsigned i = 1; i < A.size(); i++)
		if (A[i] != A[i-1])
			count++;

	return count;
}

int main()
{
	int x[6] = { 2, 1, 1, 2, 3, 1 };	// Answer: 3

	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << Distinct(v) << endl;
	cout << "Solution: " << Distinct1(v) << endl;

	cin.get();

	return 0;
}
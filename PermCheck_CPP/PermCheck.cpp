/* PermCheck - Counting Elements

A non-empty zero-indexed array A consisting of N integers is given.

A permutation is a sequence containing each element from 1 to N once, and only once.

For example, array A such that:

A[0] = 4
A[1] = 1
A[2] = 3
A[3] = 2

is a permutation, but array A such that:

A[0] = 4
A[1] = 1
A[2] = 3

is not a permutation, because value 2 is missing.

The goal is to check whether array A is a permutation.

Write a function:

int solution(vector<int> &A);

that, given a zero-indexed array A, returns 1 if array A is a permutation and 0 if it is not.

For example, given array A such that:

A[0] = 4	A[1] = 1	A[2] = 3	A[3] = 2

the function should return 1.

Given array A such that:

A[0] = 4	A[1] = 1	A[2] = 3

the function should return 0.

Assume that:

- N is an integer within the range [1..100,000];
- each element of array A is an integer within the range [1..1,000,000,000].

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <vector>
#include <numeric>
#include <climits>
#include <iostream>
#include <algorithm>

using namespace std;

// Scored 100% on www.codility.com
// Mark elements as seen in a boolean array. 
// Elements seen twice or out of bounds of the size indicate that the list is no permutation. 
// The check if the boolean array only contains true elements is not required. 
// This solution only works with permutations starting from 1.
int PermCheck(vector<int> &A) 
{
	// The use of a auto_ptr would be better, but it does not work with arrays.
	// Use of boost::scoped_array seems like an overkill.
	bool * seen = new bool[A.size()];

	for (unsigned int i = 0; i < A.size(); i++)
		seen[i] = false;

	for (unsigned int i = 0; i < A.size(); i++)
	{
		// First, if we have a permutation, then we need elements 1..N, 
		// but if any element is larger than N, then surely some elements are missing. 
		// Second, if an element occurs twice, it's a problem, 
		// that's why we create the bool array to remember already seen elements.
		//if (!(0 < A[i] && A[i] <= (int) A.size() && seen[A[i] - 1] == false))
		if (0 >= A[i] || A[i] > (int)A.size() || seen[A[i] - 1] == true)
		{
			delete[] seen;

			return 0;
		}
		else 
		{
			seen[A[i] - 1] = true;
		}
	}

	delete[] seen;

	return 1;
}


int main()
{
	int x[4] = {3, 2, 1, 4};		// Answer: 1
	// int x[4] = { 1, 3, 2, 1 };	// Answer: 0

	int size_of_array = sizeof(x);
	int size_of_element = sizeof(x[0]);
	int length = size_of_array / size_of_element;

	// Use the vector constructor that takes two iterators, 
	// note that pointers are valid iterators, and use the implicit conversion from arrays to pointers:
	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << PermCheck(v) << endl;

	cin.get();

	return 0;
}
/* MissingInteger - Counting Elements

Write a function:

int solution(vector<int> &A);

that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer that does not occur in A.

For example, given:

A[0] = 1
A[1] = 3
A[2] = 6
A[3] = 4
A[4] = 1
A[5] = 2

the function should return 5.

Assume that:

- N is an integer within the range [1..100,000];
- each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <vector>
#include <iostream>
#include <algorithm>
#include <new>

using namespace std;

// Scored 100% on www.codility.com
int MissingInteger(vector<int> &A)
{
	int i, N = A.size();

	// If there is no positive integer lacking between 1 and N, the answer should be N + 1.
	int ans = N + 1;

	// Prepare the flags
	// The C library function void *calloc(size_t nitems, size_t size) allocates the requested memory 
	// and returns a pointer to it. The difference in malloc and calloc is that malloc does not set 
	// the memory to zero where as calloc sets allocated memory to zero.
	// int * flag = (int*)calloc(N, sizeof(int));
	int * flag = new int[N];

	// Set memory to zeros
	for (i = 0; i < N; i++)
		flag[i] = 0;

	// Iterate over the given array A
	for (i = 0; i < N; i++)
	{
		// We can neglect the value below 1 or larger than N.
		if (A[i] <= 0 || A[i] > N)
		{
			continue;
		}

		// Turn on the flag. This is a zero-indexed array so give -1 is the offset.
		flag[A[i] - 1] = 1; 
	}

	// Attempt to find the minimum positive integer that is not found in the array A.
	for (i = 0; i < N; i++)
	{
		if (flag[i] == 0)
		{
			// The answer is (the index + 1). (we have -1 offset).
			ans = i + 1; 

			break; // Found the first minimal positive integer
		}
	}

	// Release the allocated memory space.
	// free(flag);
	delete [] flag;

	return ans;
}

// 1. Get the sum of numbers: total = n * (n + 1) / 2
// 2. Subtract all the numbers from sum to get the missing number.
int MissingInteger1(vector<int> &A)
{
	int i, n = A.size();

	long total = (n + 1) * (n + 2) / 2;
	// long total = n * (n + 1) / 2;

	for (i = 0; i < n; i++)
		total -= A[i];

	return (int) total;
}

// 1) XOR all the array elements, let the result of XOR be X1.
// 2) XOR all numbers from 1 to n, let XOR be X2.
// 3) XOR of X1 and X2 gives the missing number.
int MissingInteger2(vector<int> &A)
{
	int i, n = A.size();
	int x1 = A[0];	// For xor of all the elements in array
	int x2 = 1;		// For xor of all the elements from 1 to n+1

	for (i = 1; i < n; i++)
		x1 = x1^A[i];

	for (i = 2; i <= n + 1; i++)
		x2 = x2^i;

	return (x1^x2);
}

int main()
{
	int x[6] = { 1, 3, 6, 4, 1, 2 };
	// int x[6] = { 1, 2, 3, 4, 5, 7 }; // Valid for all 3 functions

	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Missing integer: " << MissingInteger(v) << endl;
	cout << "Missing integer: " << MissingInteger1(v) << endl;
	cout << "Missing integer: " << MissingInteger2(v) << endl;

	cin.get();

	return 0;
}
/* TapeEquilibrium - Time Complexity

A non-empty zero-indexed array A consisting of N integers is given. Array A represents numbers on a tape.

Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].

The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|

In other words, it is the absolute difference between the sum of the first part and the sum of the second part.

For example, consider array A such that:

A[0] = 3
A[1] = 1
A[2] = 2
A[3] = 4
A[4] = 3

We can split this tape in four places:

P = 1, difference = |3 − 10| = 7
P = 2, difference = |4 − 9| = 5
P = 3, difference = |6 − 7| = 1
P = 4, difference = |10 − 3| = 7

Write a function:

int solution(int A[], int N);

that, given a non-empty zero-indexed array A of N integers, returns the minimal difference that can be achieved.

For example, given:

A[0] = 3
A[1] = 1
A[2] = 2
A[3] = 4
A[4] = 3

the function should return 1, as explained above.

Assume that:

- N is an integer within the range [2..100,000];
- each element of array A is an integer within the range [−1,000..1,000].

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

long long TapeEquilibrium2(vector<int> &A)
{
	unsigned int size = A.size();

	vector<long long> parts;

	// Request that the vector capacity be at least enough to contain (size + 1) elements.
	parts.reserve(size + 1);

	long long last = 0;

	for (unsigned int i = 0; i < size - 1; i++)
	{
		if (i == 0)
		{
			parts.push_back(A[i]);
		}
		else
		{
			parts.push_back(A[i] + parts[i - 1]);
		}

		if (i == (size - 2))
		{
			last = parts[i] + A[i + 1];
		}
	}

	long long solution = LLONG_MAX;

	for (unsigned int i = 0; i < parts.size(); i++)
	{
		solution = min(solution, abs(last - 2 * parts[i]));
	}

	return solution;
}

// Scored 100% on www.codility.com
long TapeEquilibrium(vector<int> &A)
{
	long left = 0, right = 0, min = 0, diff = 0;

	left = std::accumulate(A.begin(), A.begin() + 1, 0);
	right = std::accumulate(A.begin() + 1, A.end(), 0);

	min = abs(left - right);

	for (size_t i = 2; i < A.size(); i++)
	{
		left += A[i-1];
		right -= A[i-1];
		diff = abs(left - right);
		min = std::min(min, diff);
	}

	return min;
}


int main()
{
	// int x[5] = {3, 1, 2, 4, 3}; // Answer: 1
	int x[6] = {3, 1, 2, 4, 3, 1};  // Answer: 2
	// int x[6] = { 5, 1, 2, 4, 3, 1 }; // Answer: 0

	int size_of_array = sizeof(x);
	int size_of_element = sizeof(x[0]);
	int length = size_of_array / size_of_element;

	// Use the vector constructor that takes two iterators, 
	// note that pointers are valid iterators, and use the implicit conversion from arrays to pointers:
	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << TapeEquilibrium(v) << endl;

	cout << "Solution: " << TapeEquilibrium2(v) << endl;

	cin.get();

	return 0;
}
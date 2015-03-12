/* PassingCars - Prefix Sums

A non-empty zero-indexed array A consisting of N integers is given. 
The consecutive elements of array A represent consecutive cars on a road.

Array A contains only 0s and/or 1s:

- 0 represents a car traveling east.
- 1 represents a car traveling west.

The goal is to count passing cars. We say that a pair of cars (P, Q), where 0 ≤ P < Q < N, 
is passing when P is traveling to the east and Q is traveling to the west.

For example, consider array A such that:

A[0] = 0	A[1] = 1	A[2] = 0	A[3] = 1	A[4] = 1

We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).

Write a function:

int solution(vector<int> &A);

that, given a non-empty zero-indexed array A of N integers, returns the number of pairs of passing cars.

The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.

For example, given:

A[0] = 0	A[1] = 1	A[2] = 0	A[3] = 1	A[4] = 1

the function should return 5, as explained above.

Assume that:

- N is an integer within the range [1..100,000];
- each element of array A is an integer that can have one of the following values: 0, 1.

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <vector>
#include <iostream>

using namespace std;

// Algorithm
//
// Count the number of passing cars on the road.
// Count all cars heading in one direction (east). 
// Each car heading in the opposite direction (west) will pass all cars that traveled east so far. 
// Note that eastbound cars at the beginning of the list pass no cars. Do not forget the upper limit.

// Solution
//
// When a car drives, we can easily see that it will drive by cars moving in the opposite direction, 
// but only if they were in front of it. Essentially that can be formulated as:
// (1) Imagine array 0..N
// (2) Take element X (iterate from 0 to Nth element)
// (3) If value of element X is 1 then count how many 0 elements it has on left to pass
// (4) Repeat for next element X

// Scored 100% on www.codility.com
int PassingCars(vector<int> &A)
{
	int eastbound_cars_cnt = 0;				// Eastbound cars counter
	unsigned long passing_cars_cnt = 0;		// Passing cars counter

	for (unsigned i = 0; i < A.size(); i++)
	{
		if (A[i] == 0)
		{
			eastbound_cars_cnt++;
		}
		else if (A[i] == 1)
		{
			passing_cars_cnt += eastbound_cars_cnt;
		}

		if (passing_cars_cnt > 1000000000)
			return -1;
	}

	return passing_cars_cnt;
}

int main()
{
	int x[5] = { 0, 1, 0, 1, 1 };	// Answer: 5

	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << PassingCars(v) << endl;

	cin.get();

	return 0;
}
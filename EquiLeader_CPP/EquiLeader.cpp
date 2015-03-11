/* EquiLeader - Leader

Find the index S such that the leaders of the sequences A[0], A[1], ..., A[S] 
and A[S + 1], A[S + 2], ..., A[N – 1] are the same.

A non-empty zero-indexed array A consisting of N integers is given.

The leader of this array is the value that occurs in more than half of the elements of A.

An equi-leader is an index S such that 0 ≤ S < N − 1 and two sequences 
A[0], A[1], ..., A[S] and A[S + 1], A[S + 2], ..., A[N − 1] have leaders of the same value.

For example, given array A such that:

A[0] = 4	A[1] = 3	A[2] = 4	A[3] = 4	A[4] = 4	A[5] = 2

we can find two equi leaders:

- 0, because sequences: (4) and (3, 4, 4, 4, 2) have the same leader, whose value is 4.
- 2, because sequences: (4, 3, 4) and (4, 4, 2) have the same leader, whose value is 4.

The goal is to count the number of equi-leaders.

Write a function:

int solution(vector<int> &A);

that, given a non-empty zero-indexed array A consisting of N integers, returns the number of equi-leaders.

For example, given:

A[0] = 4	A[1] = 3	A[2] = 4	A[3] = 4	A[4] = 4	A[5] = 2

the function should return 2, as explained above.

Assume that:

- N is an integer within the range [1..100,000];
- each element of array A is an integer within the range [−1,000,000,000..1,000,000,000].

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
int EquiLeader(vector<int> &A)
{
	int candidate = -1, leader = 0;
	unsigned leader_count = 0, candidate_count = 0;

	// Find out a leader candidate
	for (unsigned i = 0; i < A.size(); i++)
	{
		if (candidate_count == 0)
		{
			candidate = A[i];
			candidate_count++;
		}
		else
		{
			if (A[i] == candidate)
				candidate_count++;
			else
				candidate_count--;
		}
	}

	// Iterate through all the elements and count the occurrences of the candidate.
	for (unsigned i = 0; i < A.size(); i++)
	{
		if (A[i] == candidate)
			leader_count++;
	}

	// If the number of occurrences is greater than n/2 then we have found the leader.
	if (leader_count > A.size() / 2)
		leader = candidate; // Dominator (leader) was found
	else
		return leader;

	unsigned equi_leaders = 0;
	unsigned leader_count_so_far = 0;

	for (unsigned i = 0; i < A.size(); i++)
	{
		if (A[i] == leader)
			leader_count_so_far++;

		if ((leader_count_so_far >(i + 1) / 2) && ((leader_count - leader_count_so_far) > (A.size() - i - 1) / 2))
		{
			// Both the head and tail have leaders of the same value as "leader"
			equi_leaders++;
		}
	}

	return equi_leaders;
}


int main()
{
	int x[6] = { 4, 3, 4, 4, 4, 2 };       // Answer: 2

	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << EquiLeader(v) << endl;	

	cin.get();

	return 0;
}
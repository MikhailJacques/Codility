/* FibFrog - Fibonacci Numbers

Count the minimum number of jumps required for a frog to get to the other side of a river.

The Fibonacci sequence is defined using the following recursive formula:

F(0) = 0
F(1) = 1
F(M) = F(M - 1) + F(M - 2) if M >= 2

For example, 0	1	1	2	3	5	8	13	21	34	55	89	144	233	377	610	987	1597	2584	4181	6765

A small frog wants to get to the other side of a river. 
The frog is initially located at one bank of the river (position −1) and wants to get to the other bank (position N). 
The frog can jump over any distance F(K), where F(K) is the K-th Fibonacci number. 
Luckily, there are many leaves on the river, and the frog can jump between the leaves, 
but only in the direction of the bank at position N.

The leaves on the river are represented in a zero-indexed array A consisting of N integers. 
Consecutive elements of array A represent consecutive positions from 0 to N − 1 on the river. 

Array A contains only 0s and/or 1s:

- 0 represents a position without a leaf;
- 1 represents a position containing a leaf.

The goal is to count the minimum number of jumps in which the frog can get to the other side of the river 
(from position −1 to position N). 
The frog can jump between positions −1 and N (the banks of the river) and every position containing a leaf.

For example, consider array A such that:

A[0] = 0	A[1] = 0	A[2] = 0	A[3] = 1	A[4] = 1	
A[5] = 0	A[6] = 1	A[7] = 0	A[8] = 0	A[9] = 0	A[10] = 0

The frog can make three jumps of length F(5) = 5, F(3) = 2 and F(5) = 5.

Write a function:

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A consisting of N integers, 
returns the minimum number of jumps by which the frog can get to the other side of the river.

If the frog cannot reach the other side of the river, the function should return −1.

For example, given:

A[0] = 0	A[1] = 0	A[2] = 0	A[3] = 1	A[4] = 1	
A[5] = 0	A[6] = 1	A[7] = 0	A[8] = 0	A[9] = 0	A[10] = 0

the function should return 3, as explained above.

Assume that:

- N is an integer within the range [0..100,000];
- each element of array A is an integer that can have one of the following values: 0, 1.

Complexity:

- expected worst-case time complexity is O(N*log(N));
- expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <queue>
#include <vector>
#include <climits>
#include <iostream>
#include <algorithm>

using namespace std;

// Algorithm
//
// This problem can be solved in a Dynamic Programming way. 
// We need to know the optimal count of jumps that can reach a given leaf. 
// We get those by either reaching the leaf from the first shore or by reaching it from another leaf.
// The N * log(N) time complexity is given by the fact, 
// that there are approximately log(N) Fibonacci numbers up to N and we visit each position once.

vector<int> dynamicFibs(int n) 
{
	vector<int> fibs;

	fibs.push_back(0);
	fibs.push_back(1);

	for (int i = 2; i <= n + 2; i++) 
	{
		int tmp = fibs[i - 1] + fibs[i - 2];

		if (tmp > n + 2) 
		{
			break;
		}

		fibs.push_back(tmp);
	}

	return fibs;
}

typedef struct state 
{
	int pos;
	int step;
} state;


// Solution
//
// Scored 100% on www.codility.com
int FibFrog(vector<int> &A) 
{
	if (A.size() == 0)
		return 1;

	bool * visited = new bool[A.size()];

	vector<int> fibs = dynamicFibs(A.size());

	int maxAction = fibs.size();

	fill(visited, visited + A.size(), false);

	queue<state> q;

	state start = { -1, 0 };

	q.push(start);

	while (!q.empty()) 
	{
		state s = q.front();

		q.pop();

		for (int i = maxAction - 1; i >= 1; i--) 
		{
			int nextPos = s.pos + fibs[i];

			if (nextPos == A.size())
			{
				return s.step + 1;
			}

			if (nextPos > A.size() || A[nextPos] == 0 || visited[nextPos] == true)
			{
				continue;
			}

			state next;

			next.pos = nextPos;

			next.step = s.step + 1;

			q.push(next);

			visited[nextPos] = true;
		}
	}

	return -1;
}

int main()
{
	int a[11] = { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 };		// Answer: 3	 

	vector<int> A(a, a + sizeof(a) / sizeof(a[0]));

	cout << "Solution: " << FibFrog(A) << endl;

	cin.get();

	return 0;
}
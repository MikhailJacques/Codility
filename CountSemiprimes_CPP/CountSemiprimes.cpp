/* CountSemiprimes - Sieve of Eratosthenes

Count the semiprime numbers in the given range [a..b].

A prime is a positive integer X that has exactly two distinct divisors: 1 and X. 
The first few prime integers are 2, 3, 5, 7, 11 and 13.

A semiprime is a natural number that is the product of two (not necessarily distinct) prime numbers. 
The first few semiprimes are 4, 6, 9, 10, 14, 15, 21, 22, 25, 26.

You are given two non-empty zero-indexed arrays P and Q, each consisting of M integers. 
These arrays represent queries about the number of semiprimes within specified ranges.

Query K requires you to find the number of semiprimes within the range (P[K], Q[K]), where 1 ≤ P[K] ≤ Q[K] ≤ N.

For example, consider an integer N = 26 and arrays P, Q such that:

P[0] = 1    Q[0] = 26
P[1] = 4    Q[1] = 10
P[2] = 16   Q[2] = 20

The number of semiprimes within each of these ranges is as follows:

(1, 26) is 10,
(4, 10) is 4,
(16, 20) is 0.

Write a function:

vector<int> solution(int N, vector<int> &P, vector<int> &Q);

that, given an integer N and two non-empty zero-indexed arrays P and Q consisting of M integers, 
returns an array consisting of M elements specifying the consecutive answers to all the queries.

For example, given an integer N = 26 and arrays P, Q such that:

P[0] = 1    Q[0] = 26
P[1] = 4    Q[1] = 10
P[2] = 16   Q[2] = 20

the function should return the values [10, 4, 0], as explained above.

Assume that:

- N is an integer within the range [1..50,000];
- M is an integer within the range [1..30,000];
- each element of arrays P, Q is an integer within the range [1..N];
- P[i] ≤ Q[i].

Complexity:

- expected worst-case time complexity is O(N*log(log(N))+M);
- expected worst-case space complexity is O(N+M), beyond input storage 
  (not counting the storage required for input arguments).

Elements of input arrays can be modified.

*/

#include <vector>
#include <climits>
#include <iostream>
#include <algorithm>

using namespace std;

// Algorithm
//
// First get all semiprimes from an adaptation of the Sieve of Eratosthenes.
// Because we will be computing the difference many times a prefix sum is adequate.
// Get the number of semiprimes up to the point.
// The index P is decreased by 1 because we want to know all primes that start from P.

vector<int> Eratosphen(int N)
{
	vector<int> primes;
	vector<bool> marked(N + 1, true);

	for (int i = 2; i <= sqrt(N); i++)
	{
		if (marked[i])
		{
			for (int k = i * i; k <= N; k += i)
			{
				marked[k] = false;
			}
		}
	}

	for (int i = 2; i <= N; i++)
	{
		if (marked[i])
		{
			primes.push_back(i);
		}
	}

	return primes;
}

vector<int> calcSemiPrimes(const vector<int> &primes, int N)
{
	vector<int> semiPrimes;

	for (vector<int>::const_iterator i = primes.begin(); i != primes.end(); ++i)
	{
		for (vector<int>::const_iterator j = i; j != primes.end(); ++j)
		{
			int product = (*i) * (*j);

			if ((product <= N) && (product > 0))
			{
				semiPrimes.push_back((*i) * (*j));
			}
		}
	}

	std::sort(semiPrimes.begin(), semiPrimes.end());

	return semiPrimes;
}

vector<int> countSemiPrimes(const vector<int> &semiPrimes, int N)
{
	vector<int> countSemiPrimes(N + 1, 0);

	for (vector<int>::const_iterator i = semiPrimes.begin(); i != semiPrimes.end(); ++i)
	{
		countSemiPrimes[*i]++;
	}

	for (vector<int>::iterator i = countSemiPrimes.begin() + 1; i != countSemiPrimes.end(); ++i)
	{
		size_t index = i - countSemiPrimes.begin();

		countSemiPrimes[index] += countSemiPrimes[index - 1];
	}

	return countSemiPrimes;
}

vector<int> processQuerries(const vector<int> &P, const vector<int> &Q, const vector<int> &numSemiPrimes)
{
	size_t size = P.size();

	vector<int> result(size, 0);

	for (size_t i = 0; i < size; i++)
	{
		result[i] = numSemiPrimes[Q[i]] - numSemiPrimes[P[i] - 1];
	}

	return result;
}

// Solution
//
// Scored 100% on www.codility.com
// Detected time complexity: O(N * log(log(N)) + M)
vector<int> CountSemiprimes(int N, const vector<int> &P, const vector<int> &Q)
{
	vector<int> primes = Eratosphen(N); // Sieve of Eratosthenes
	vector<int> semiPrimes = calcSemiPrimes(primes, N);
	vector<int> numSemiPrimes = countSemiPrimes(semiPrimes, N);

	return processQuerries(P, Q, numSemiPrimes);
}

int main()
{
	int N = 26;					// Answer: (10,4,0)
	int p[3] = { 1, 4, 16 };
	int q[3] = { 26, 10, 20 };

	vector<int> P(p, p + sizeof(p) / sizeof(p[0]));
	vector<int> Q(q, q + sizeof(q) / sizeof(q[0]));

	vector<int> result = CountSemiprimes(N, P, Q);

	cout << "(";
	for (unsigned i = 0; i < result.size(); i++)
		cout << result[i] << ",";
	cout << ")";

	cin.get();

	return 0;
}
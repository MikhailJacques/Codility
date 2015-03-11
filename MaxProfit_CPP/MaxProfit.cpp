/* MaxProfit - Maximum Slice Problem

Given a log of stock prices compute the maximum possible earning.

A zero-indexed array A consisting of N integers is given. 
It contains daily prices of a stock share for a period of N consecutive days. 
If a single share was bought on day P and sold on day Q, where 0 ≤ P ≤ Q < N, 
then the profit of such transaction is equal to A[Q] − A[P], provided that A[Q] ≥ A[P]. 
Otherwise, the transaction brings loss of A[P] − A[Q].

For example, consider the following array A consisting of six elements such that:

A[0] = 23171	A[1] = 21011	A[2] = 21123	A[3] = 21366	A[4] = 21013	A[5] = 21367

If a share was bought on day 0 and sold on day 2, a loss of 2048 would occur because A[2] − A[0] = 21123 − 23171 = −2048. 

If a share was bought on day 4 and sold on day 5, a profit of 354 would occur because A[5] − A[4] = 21367 − 21013 = 354. 

Maximum possible profit was 356. It would occur if a share was bought on day 1 and sold on day 5.

Write a function,

int solution(vector<int> &A);

that, given a zero-indexed array A consisting of N integers containing daily prices of a stock share for 
a period of N consecutive days, returns the maximum possible profit from one transaction during this period. 
The function should return 0 if it was impossible to gain any profit.

For example, given array A consisting of six elements such that:

A[0] = 23171	A[1] = 21011	A[2] = 21123	A[3] = 21366	A[4] = 21013	A[5] = 21367

the function should return 356, as explained above.

Assume that:

- N is an integer within the range [0..400,000];
- each element of array A is an integer within the range [0..200,000].

Complexity:

- expected worst-case time complexity is O(N);
- expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

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
int MaxProfit(vector<int> &A)
{
	if (A.size() == 0 || A.size() == 1)
		return 0;

	int max_profit = 0, max_slice = 0;

	for (unsigned i = 1; i < A.size(); i++)
	{
		max_slice = std::max(0, max_slice + (A[i] - A[i - 1]));
		max_profit = std::max(max_profit, max_slice);
	}

	return max_profit;
}

// Solution
//
// Scored 66% on www.codility.com 
int MaxProfit2(vector<int> &A)
{
	if (A.size() == 0 || A.size() == 1)
		return 0;

	int max_profit = 0, min_daily_price = 200000;

	// Where A[i] is a daily stock price
	for (unsigned i = 1; i < A.size(); i++)
	{
		min_daily_price = std::min(A[i], min_daily_price);
		max_profit = std::max(max_profit, A[i] - min_daily_price);
	}

	// Just another way for solving the problem. Same as above.
	int maxEndingHere = 0, minPrice = A[0], maxSoFar = 0;
	for (unsigned i = 1; i < A.size(); i++)
	{
		maxEndingHere = std::max(0, A[i] - minPrice);
		minPrice = std::min(minPrice, A[i]);
		maxSoFar = std::max(maxEndingHere, maxSoFar);
	}

	return max_profit;
}

int main()
{
	int x[7] = { 23171, 21011, 21123, 21366, 21366, 21013, 21367 };  // Answer: 356

	vector<int> v(x, x + sizeof(x) / sizeof(x[0]));

	cout << "Solution: " << MaxProfit(v) << endl;
	cout << "Solution: " << MaxProfit2(v) << endl;

	cin.get();

	return 0;
}
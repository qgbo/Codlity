

namespace Semiprime
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class Data
	{
		public int v;
		public int i;
		public bool isPrime;
	}
	class Solution
	{


		public int[] solution(int N, int[] P, int[] Q)
		{
			var primes = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293 };

			var arr = primes.TakeWhile(t => 2 * t <= N).ToArray(); // the mininum value is 2

			var semiprime = new HashSet<int>();

			foreach (var item in arr)
			{
				foreach (var s in arr)
				{
					semiprime.Add(item * s);
				}
			}

			var semiprimeArr = semiprime.Where(t => t <= N).OrderBy(t => t).ToList();



			var result = new List<int>();
			for (int i = 0; i < P.Length; i++)
			{
				var s = -1;
				var b = -1;
				for (int k = 0; k < semiprimeArr.Count - 1; k++)
				{
					if (semiprimeArr[k+1] >= P[i] && s!=-1)
					{
						s = k;
					}

					if (semiprimeArr[k + 1] >= Q[i] && k != -1)
					{
						b = k;
						continue;
					}
				}

				if (s == -1)
				{
					if (b == -1)
					{
						result.Add(0);
						continue;
					}
					else
						s = 0;
				}

				result.Add(b - s + 1);
			}

			return result.ToArray();
		}
		public int[] solution4(int N, int[] P, int[] Q)
		{
			var primes = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293 };

			var arr = primes.TakeWhile(t => 2 * t <= N).ToArray(); // the mininum value is 2

			var semiprime = new HashSet<int>();

			foreach (var item in arr)
			{
				foreach (var s in arr)
				{
					semiprime.Add(item * s);
				}
			}

			var semiprimeArr = semiprime.Where(t => t <= N).OrderBy(t => t).ToList();



			var result = new List<int>();
			for (int i = 0; i < P.Length; i++)
			{
				var s = semiprimeArr.FindIndex(t => t >= P[i]);

				var b = semiprimeArr.FindLastIndex(t => t <= Q[i]);
				if (s == -1)
				{
					if (b == -1)
					{
						result.Add(0);
						continue;
					}
					else
						s = 0;
				}

				result.Add(b - s + 1);
			}

			return result.ToArray();
		}
		public int[] solution3(int N, int[] P, int[] Q)
		{
			var primes = new List<Data>();

			var n = N;
			for (int i = 0; i <= n + 1; i++)
			{
				primes.Add(new Data() { v = i, isPrime = true, i = primes.Count });
			}


			for (int i = 2; i * i <= n + 1; i++)
			{
				if (primes[i].isPrime)
				{
					for (int j = i; i * j < n + 1; j++)
					{
						primes[i * j].isPrime = false;
					}
				}
			}


			primes.RemoveAll(t => t.isPrime == false || t.i == 0 || t.i == 1);

			var ss = primes.Select(t => t.v);

			var semiprime = new HashSet<int>();

			foreach (var item in ss)
			{
				foreach (var s in ss)
				{
					semiprime.Add(item * s);
				}
			}
			var semiprimeArr = semiprime.Where(t => t <= N).OrderBy(t => t).ToList();



			var result = new List<int>();
			for (int i = 0; i < P.Length; i++)
			{
				var b = semiprimeArr.BinarySearch(Q[i]);


				var s = semiprimeArr.BinarySearch(P[i]);

				if (b == s)
				{
					result.Add(0);
					continue;
				}

				if (b > 0)
				{
					if (s >= 0)
						result.Add(Math.Abs(b - s + 1));
					else
						result.Add(Math.Abs(b + 2 + s));
				}
				else
				{
					if (s >= 0)
						result.Add(Math.Abs(-b - s - 1));
					else
						result.Add(Math.Abs(-b + s));
				}

			}

			return result.ToArray();
		}

		public int[] solution2(int N, int[] P, int[] Q)
		{
			var primes = new List<Data>();

			var n = N;
			for (int i = 0; i <= n + 1; i++)
			{
				primes.Add(new Data() { v = i, isPrime = true, i = primes.Count });
			}


			for (int i = 2; i * i <= n + 1; i++)
			{
				if (primes[i].isPrime)
				{
					for (int j = i; i * j < n + 1; j++)
					{
						primes[i * j].isPrime = false;
					}
				}
			}

			primes.RemoveAll(t => t.isPrime == false || t.i == 0 || t.i == 1);

			var ss = primes.Select(t => t.v);

			var semiprime = new HashSet<int>();

			foreach (var item in ss)
			{
				foreach (var s in ss)
				{
					semiprime.Add(item * s);
				}
			}
			var semiprimeArr = semiprime.Where(t => t <= N).OrderBy(t => t).ToList();

			var result = new List<int>();
			for (int i = 0; i < P.Length; i++)
			{
				var r = semiprimeArr.Count(t => P[i] <= t && Q[i] >= t);
				result.Add(r);
			}

			return result.ToArray();
		}
		public static void Test()
		{

			Random randNum = new Random();

			for (int i = 0; i < 40; i++)
			{
				continue;
				int[] test3 = Enumerable.Repeat(0, 24)
							 .Select(t => randNum.Next(0, 200))
							 .ToArray();


				int[] test2 = Enumerable.Repeat(0, 24)
							.Select(t => randNum.Next(200, 400))
							.ToArray();

				var s3 = new Solution().solution(30000, test3, test2);
				var s33 = new Solution().solution2(30000, test3, test2);
				if (string.Join(",", s3) != string.Join(",", s33))
				{
					Console.WriteLine(string.Join(",", test3));
					Console.WriteLine(string.Join(",", test2));
					Console.WriteLine();
				}
			}

			//var s = new Solution().solution(20, new int[] { 4, 2, 0, 0, 11, 6, 10, 7, 11, 5 }, new int[] { 0, 4, 11, 6, 7, 3, 8, 2, 11, 8 });
			//Console.WriteLine(string.Join(",", s));

			//var ss = new Solution().solution2(20, new int[] { 4, 2, 0, 0, 11, 6, 10, 7, 11, 5 }, new int[] { 0, 4, 11, 6, 7, 3, 8, 2, 11, 8 });
			//Console.WriteLine(string.Join(",", ss));

			//         var s1 = new Solution().solution(26, new int[] { 1, 4, 16 }, new int[] { 26, 10, 20 });
			//Console.WriteLine(string.Join(",", s1));

			var s11 = new Solution().solution(60, new int[] { 10, 4, 7, 19, 6, 5, 4, 16, 8, 17 }, new int[] { 31, 21, 36, 35, 32, 38, 22, 37, 29, 22, 24, 39, 24, 35, 33 });
			Console.WriteLine(string.Join(",", s11));

			var s2 = new Solution().solution2(60, new int[] { 10, 4, 7, 19, 6, 5, 4, 16, 8, 17 }, new int[] { 31, 21, 36, 35, 32, 38, 22, 37, 29, 22, 24, 39, 24, 35, 33 });
			Console.WriteLine(string.Join(",", s2));
		}
	}
}
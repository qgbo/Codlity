

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


				if (b ==s && s <0)
				{
					result.Add(0);
					continue;
				}

				if (-b > semiprimeArr.Count)
				{
					b = semiprimeArr.Count - 1;
				}
				else if (b < 0)
					b = -b - 1;

				if (-s > semiprimeArr.Count)
				{
					s = semiprimeArr.Count - 1;
				}
				else if (s < 0)
					s = -s - 1;

			    result.Add(b - s + 1);
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

			//for (int i = 0; i < 20; i++)
			//{
			//	int[] test3 = Enumerable.Repeat(0, 5)
			//				 .Select(t => randNum.Next(4, 12))
			//				 .ToArray();


			//	int[] test2 = Enumerable.Repeat(0, 5)
			//				.Select(t => randNum.Next(16, 40))
			//				.ToArray();

			//	var s3 = new Solution().solution(40, test3, test2);
			//	var s2 = new Solution().solution2(40, test3, test2);
			//	if (string.Join(",", s3) != string.Join(",", s2))
			//	{
			//		Console.WriteLine(string.Join(",", test3));
			//		Console.WriteLine(string.Join(",", test2));
			//		Console.WriteLine();
			//	}
			//}

			//var s = new Solution().solution(20, new int[] { 4, 2, 0, 0, 11, 6, 10, 7, 11, 5 }, new int[] { 0, 4, 11, 6, 7, 3, 8, 2, 11, 8 });
			//Console.WriteLine(string.Join(",", s));

			//var ss = new Solution().solution2(20, new int[] { 4, 2, 0, 0, 11, 6, 10, 7, 11, 5 }, new int[] { 0, 4, 11, 6, 7, 3, 8, 2, 11, 8 });
			//Console.WriteLine(string.Join(",", ss));


			Console.WriteLine("over!");

			var s1 = new Solution().solution(26, new int[] { 6, 6, 4, 6, 5 }, new int[] { 32, 20, 30, 35, 27 });
			Console.WriteLine(string.Join(",", s1));

			var s2 = new Solution().solution2(26, new int[] { 6, 6, 4, 6, 5 }, new int[] { 32, 20, 30, 35, 27 });
			Console.WriteLine(string.Join(",", s2));
		}
	}
}

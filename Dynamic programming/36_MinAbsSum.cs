
namespace MinAbsSum2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	class Solution
	{

		public int solution2(int[] A)
		{
			var datap = new int[A.Length];
			var datan = new int[A.Length];

			datap[0] = Math.Abs(A[0]);
			datan[0] = -Math.Abs(A[0]);

			for (int i = 1; i < A.Length; i++)
			{
				A[i] = Math.Abs(A[i]);
				var p = Math.Min(A[i] + datap[i - 1], -A[i] + datap[i - 1]);
				var n = Math.Min(A[i] - datap[i - 1], -A[i] - datap[i - 1]);
				datan[0] = Math.Min(p, n);
			}

			return 0;
		}

	
		/// <summary>
		/// 55 score
		/// </summary>
		/// <param name="A"></param>
		/// <returns></returns>
		public int solution(int[] A)
		{
			var data = new List<List<int>>();
			var n = 2;
			data.Add(new List<int>());
			data[0].Add(0);

			for (int i = 0; i < A.Length; i++)
			{
				data.Add(new List<int>());
				
				for (int j = 0; j < n; j++)
				{

					data[i + 1].Add(data[i][j/2]+ (j%2==0? A[i] :-A[i]));
				}
				n *= 2;
			}
			Console.WriteLine(string.Join(",", data.Last()));
			return data.Last().Min(t => Math.Abs(t));
		}

		public static void Test()
		{
			var s = new Solution().solution(new int[] { 1,2,3,6 });
			Console.WriteLine(s);


			s= new Solution().solution(new int[] { 1, 2, 3, 6,7 });
			Console.WriteLine(s);

			s=new Solution().solution(new int[] { 1, 2, 3, 6,9 });

			Console.WriteLine(s);

		}
	}
}

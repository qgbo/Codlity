

namespace CountNonDivisible
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	class Data
	{
		public int i;
		public int v;
		public int result;
	}
	class Solution
	{
		public int[] solution(int[] A)
		{
			var data = new List<Data>();
			for (int i = 0; i < A.Length; i++)
			{
				data.Add(new Data { v = A[i], i = i }); ;
			}

			var mm = data.OrderBy(t => t.v).ToArray();


			mm[0].result=  A.Count(t => mm[0].v % t != 0);

			for (int i = 1; i < mm.Length; i++)
			{
				if (mm[i].v == mm[i - 1].v)
					{
						mm[i].result = mm[i - 1].result;
						continue;
					}

				var d = mm[i];
				var arr = mm.TakeWhile(t => t.v <= d.v);
				d.result = arr.Count(t => d.v % t.v != 0);
			}

			return data.OrderBy(t => t.i).Select(t => t.result).ToArray();
		}


		public int[] solution3(int[] A)
		{

			var result = new List<int>();

			foreach (var a in A)
			{
				int c = 0;
				foreach (var item in A)
				{
					if (a < item || a % item != 0)
						c++;
				}
				result.Add(c);
			}

			return result.ToArray();
		}

		public int[] solution2(int[] A)
		{

			var result = new List<int>();

			foreach (var a in A)
			{
				var c = A.Count(t => a % t != 0);
				result.Add(c);
			}

			return result.ToArray();
		}

		public static void Test()
		{
			var s = new Solution().solution(new int[] { 3, 1, 2, 3, 6 });
			Console.WriteLine(string.Join(",", s));
		}
	}
}
